using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public Transform tailFin;
    float tailFinPos_x;
    float moveSpeed;
    Rigidbody2D rb;
    float initialPos;

	// Use this for initialization
	void Start () {
        tailFinPos_x = tailFin.localPosition.x;
        rb = GetComponent<Rigidbody2D>();
        initialPos = transform.position.x;
        moveSpeed = -0.3f;
	}
	
	// Update is called once per frame

    // ローカル座標-5~0の間を行ったり来たりする
	void Update () {
        if (transform.position.x - initialPos > 0){
            moveSpeed = -0.3f;
            transform.localScale = new Vector2(1, 1);
        }else if (transform.position.x - initialPos < -5)
        {
            moveSpeed = 0.3f;
            transform.localScale = new Vector2(-1, 1);
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
	}
}
