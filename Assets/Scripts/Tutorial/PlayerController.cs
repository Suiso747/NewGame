using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを操作を行う

public class PlayerController : MonoBehaviour {


    public GameObject gameManager;
    public GameObject eyes;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;
    public GameObject eye4;

    public LayerMask blockLayer; // ブロックレイヤー(このレイヤーと上から接しているときはジャンプ可能)

    Rigidbody2D rb;

    const float MOVE_SPEED = 3; // 移動速度固定値
    float moveSpeed; // ゲーム中の移動速度
    [HideInInspector] public float speedRate = 1.0f; // 移動速度倍率
    [HideInInspector] public bool reverse; // 左右反転

    float jumpPower = 120; // ジャンプ力
    bool goJump = false; // ジャンプしたか否か
    bool canJump = false; // ジャンプできるか否か

    // サウンド関係
    AudioSource audioSource;
    public AudioClip jumpSE; // ジャンプSE
    public AudioClip groundedSE; // 着地SE
    bool beepedGroundedSE = true; // 着地SEを鳴らしたか
    public AudioClip saveSE; // セーブSE

    // 最後にセーブしたセーブポイントのIDと座標
    string ID = "SaveID";
    string X = "SaveX";
    string Y = "SaveY";

    // プレイヤーの進行方向
    public enum MOVE_DIR
    {
        STOP,
        LEFT,
        RIGHT,
    };

    MOVE_DIR moveDirection = MOVE_DIR.STOP; // 移動方向初期化

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        speedRate = 1;

        // セーブ地点から再開
        int RestartPoint = PlayerPrefs.GetInt(ID, 0);
        if (RestartPoint != 0)
        {
            Debug.Log("relocated");
            Debug.Log(PlayerPrefs.GetFloat(X) + ", " + PlayerPrefs.GetFloat(Y));
            transform.position = new Vector3(PlayerPrefs.GetFloat(X), PlayerPrefs.GetFloat(Y), 0);



        }


    }


	

	void Update () {

        // プレイヤーの下端に線分を引き、それがブロックレイヤーと接触しているか判定
        canJump =
            Physics2D.Linecast((transform.position - transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer) ||
            Physics2D.Linecast((transform.position + transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer);

        if (!canJump ){ // 上昇 or 下降 で目のスプライト位置を変更
            if (rb.velocity.y > 0){
                eyes.transform.localPosition = new Vector3(eyes.transform.localPosition.x,
                                                     0.1f,
                                                     eyes.transform.localPosition.z);
            }
            else{
                eyes.transform.localPosition = new Vector3(eyes.transform.localPosition.x,
                                                     -0.1f,
                                                     eyes.transform.localPosition.z);
            }
        }else{
                eyes.transform.localPosition = new Vector3(eyes.transform.localPosition.x,
                                                     0.0f,
                                                     eyes.transform.localPosition.z);
        }

        if (canJump && !beepedGroundedSE){
            audioSource.clip = groundedSE;
            audioSource.time = 0.1f;  // SEの再生時間微調整


            audioSource.Play();

            beepedGroundedSE = true;
        }
      

        float x = Input.GetAxisRaw("Horizontal"); // キーボードの左右を押しているか
        if (reverse){
            x = -x;
        }

        if (x > 0){
            moveDirection = MOVE_DIR.RIGHT;
            eye1.SetActive(true);
            eye2.SetActive(true);
            eye3.SetActive(false);
            eye4.SetActive(false);
        } else if (x < 0){
            moveDirection = MOVE_DIR.LEFT;
            eye1.SetActive(false);
            eye2.SetActive(false);
            eye3.SetActive(true);
            eye4.SetActive(true);
        } else {
            moveDirection = MOVE_DIR.STOP;
        }

        if (Input.GetKeyDown("space")){
            if (canJump){
                goJump = true;
            }
           
        }
	}

    void FixedUpdate(){

        // 移動方向で処理分岐
        switch (moveDirection){
            case MOVE_DIR.RIGHT:
                moveSpeed = MOVE_SPEED * speedRate;
                break;
            case MOVE_DIR.LEFT:
                moveSpeed = -MOVE_SPEED * speedRate;
                break;
            case MOVE_DIR.STOP:
                moveSpeed = 0f;
                break;
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // y方向は速度保存

        // ジャンプ処理
        if (goJump){
            audioSource.clip = jumpSE;
            audioSource.time = 0.05f; // SEの再生時間微調整
            audioSource.Play();
            rb.AddForce(Vector2.up * jumpPower);
            goJump = false;
            beepedGroundedSE = false;
           
        }
    }


    // 衝突処理
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameManager.GetComponent<GameManager>().gameState != GameManager.GAME_STATE.PLAY){
            return;

        }
        // 接触している物体が赤色か 
        if (collision.gameObject.GetComponent<SpriteRenderer>().color.r >= 0.85 &&
            collision.gameObject.GetComponent<SpriteRenderer>().color.r <= 0.86 &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.g >= 0.25 &&
            collision.gameObject.GetComponent<SpriteRenderer>().color.g <= 0.26 &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.b >= 0.21 &&
            collision.gameObject.GetComponent<SpriteRenderer>().color.b <= 0.22)
        {
            // ミスした時の処理 (アニメーション)
            Debug.Log("MISS");
            gameObject.SetActive(false);
            gameManager.GetComponent<GameManager>().Miss();
        }

        // ゴールだったら
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("CLEAR");
            gameObject.SetActive(false);
            gameManager.GetComponent<GameManager>().Clear();
        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        // 水に入るときの処理
        if (collision.gameObject.tag == "Water"){
            if (rb.gravityScale > 0){
                rb.gravityScale = -rb.gravityScale;
            }

            rb.drag = 1;
        }

        // セーブ地点に接触したときの処理
        if (collision.gameObject.tag == "Flag")
        {
            if (PlayerPrefs.GetInt(ID, 0) != collision.gameObject.GetComponent<SavePoint>().SAVE_ID){
                Debug.Log("saved");
                audioSource.clip = saveSE;
                audioSource.time = 0.1f;  // SEの再生時間微調整
                audioSource.Play();
                collision.GetComponent<SavePoint>().Save();
            }
      
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 水から出るときの処理
        if (collision.gameObject.tag == "Water")
        {
            rb.gravityScale = 3; //デフォルト値
            rb.drag = 0;
        }
    }


    // 水平に動く床で滑らないようにする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MoveStage")
        {
            Debug.Log("collision");
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MoveStage")
        {
            transform.SetParent(null);
        }
    }

}
