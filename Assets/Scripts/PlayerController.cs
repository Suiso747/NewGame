using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを操作を行う

public class PlayerController : MonoBehaviour {


    public GameObject gameManager;

    public LayerMask blockLayer; // ブロックレイヤー(このレイヤーと上から接しているときはジャンプ可能)

    Rigidbody2D rb;

    const float MOVE_SPEED = 3; // 移動速度固定値
    float moveSpeed; // ゲーム中の移動速度

    float jumpPower = 120; // ジャンプ力
    bool goJump = false; // ジャンプしたか否か
    bool canJump = false; // ジャンプできるか否か

    // サウンド関係
    AudioSource audioSource;
    public AudioClip jumpSE; // ジャンプSE
    public AudioClip groundedSE; // 着地SE
    bool beepedGroundedSE = true; // 着地SEを鳴らしたか

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
	}
	

	void Update () {

        // プレイヤーの下端に線分を引き、それがブロックレイヤーと接触しているか判定
        canJump =
            Physics2D.Linecast((transform.position - transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer) ||
            Physics2D.Linecast((transform.position + transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer);

        if (canJump && !beepedGroundedSE){
            audioSource.clip = groundedSE;
            audioSource.time = 0.1f;  // SEの再生時間微調整
            audioSource.Play();

            beepedGroundedSE = true;
        }
      

        float x = Input.GetAxisRaw("Horizontal"); // キーボードの左右を押しているか

        if (x > 0){
            moveDirection = MOVE_DIR.RIGHT;
        } else if (x < 0){
            moveDirection = MOVE_DIR.LEFT;
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
                moveSpeed = MOVE_SPEED;
                break;
            case MOVE_DIR.LEFT:
                moveSpeed = -MOVE_SPEED;
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
        if (collision.gameObject.GetComponent<SpriteRenderer>().color.r >= 0.9f &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.g <= 0.1f &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.b <= 0.1f)
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


}
