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
	}
	

	void Update () {

        // プレイヤーの下端に線分を引き、それがブロックレイヤーと接触しているか判定
        canJump =
            Physics2D.Linecast((transform.position - transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer) ||
            Physics2D.Linecast((transform.position + transform.right * 0.1f - (transform.up * 0.15f)),
                               transform.position - (transform.up * 0.25f), blockLayer);

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
        if (goJump){
            rb.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
    }


    // 衝突処理
    private void OnCollisionStay2D(Collision2D collision)
    {
        // 接触している物体が赤色か 

        if (collision.gameObject.GetComponent<SpriteRenderer>().color.r >= 0.9f &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.g <= 0.1f &&
           collision.gameObject.GetComponent<SpriteRenderer>().color.b <= 0.1f)
        {
            // ミスした時の処理 (アニメーション)
            Debug.Log("MISS");
            GameObject.Find("GameManager").GetComponent<GameManager>().Miss();
        }
    }  

}
