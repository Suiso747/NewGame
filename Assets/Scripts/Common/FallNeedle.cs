using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FallNeedle : MonoBehaviour {



    // 進行ベクトル
    public enum NEEDLE_DIR
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    };
    
    public NEEDLE_DIR dir = NEEDLE_DIR.UP;
    public float sensorRange = 0.5f; // 針が動き始める範囲
    Rigidbody2D rb;

    GameObject player;
    bool NeedleGo = false;
    public float moveSpeed = 3f;

    AudioSource audioSource;
    public AudioClip needleSE; // 針が落ち始めるときのSE

    void Start () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
	}
	
    // x座標またはy座標が一致したらプレイヤーに向かって進行するフラグを立てる
	void Update () {
        if (!NeedleGo){
            switch (dir)
            {
                // 針が上を向いているとき
                case NEEDLE_DIR.UP:
                    if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < sensorRange)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
                        Destroy(this.gameObject, 5f);
                        audioSource.PlayOneShot(needleSE);
                        NeedleGo = true;
                    }
                    break;
                // 針が下を向いているとき
                case NEEDLE_DIR.DOWN:
                    if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < sensorRange)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
                        Destroy(this.gameObject, 5f);
                        audioSource.PlayOneShot(needleSE);
                        NeedleGo = true;
                    }
                    break;
                // 針が左を向いているとき
                case NEEDLE_DIR.LEFT:
                    if (Mathf.Abs(this.transform.position.y - player.transform.position.y) < sensorRange)
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        Destroy(this.gameObject, 5f);
                        audioSource.PlayOneShot(needleSE);
                        NeedleGo = true;
                    }
                    break;
                // 針が右を向いているとき
                case NEEDLE_DIR.RIGHT:
                    if (Mathf.Abs(this.transform.position.y - player.transform.position.y) < sensorRange)
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        Destroy(this.gameObject, 5f);
                        audioSource.PlayOneShot(needleSE);
                        NeedleGo = true;
                    }
                    break;
            }
        }             
	}
}
