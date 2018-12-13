using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBlock : MonoBehaviour
{

    // 初期のローカル座標を(0,0)として、指定したローカル座標(x,y)までの間を
    // blockSpeedで往復する
    // 端点ではstopTimeだけ停止する

    public float moveSpeed = 0.2f;
    Vector2 moveVec;
    public Vector2 destinationPos = new Vector2(3.0f, 0.0f);
    Vector2 initialPos;
    public float stopTime = 2.0f;

    enum STATE
    {
        GO,
        RETURN,
        STOP,
    }
    STATE state;

    // Use this for initialization
    void Start()
    {    
        initialPos = transform.position;
        destinationPos = initialPos + destinationPos;
        state = STATE.GO;

    }

    // Update is called once per frame

    void Update()
    {
        if (state == STATE.GO)
        {
            moveVec = (destinationPos - initialPos)*moveSpeed * Time.deltaTime;

            if (Mathf.Abs(destinationPos.x-transform.position.x)< 0.3f 
                && Mathf.Abs(destinationPos.y - transform.position.y) < 0.3f)
            {                

                StartCoroutine("Stop");
            }

        }
        else if (state == STATE.RETURN)
        {
            moveVec = (initialPos - destinationPos)* moveSpeed * Time.deltaTime;

            if (Mathf.Abs(initialPos.x - transform.position.x) < 0.3f
                && Mathf.Abs(initialPos.y - transform.position.y) < 0.3f)
            {
                StartCoroutine("Stop");
            }

        } else if (state == STATE.STOP)
        {
            moveVec = new Vector2(0, 0);
        }

        transform.localPosition = new Vector2(transform.localPosition.x + moveVec.x, transform.localPosition.y + moveVec.y);

    }

    IEnumerator Stop()
    {
        if (state == STATE.GO){
            state = STATE.STOP;
            //this.tag = "Untagged";
            yield return new WaitForSeconds(stopTime);
            //this.tag = "MoveStage";
            state = STATE.RETURN;
        }else{
            state = STATE.STOP;
            //this.tag = "Untagged";
            yield return new WaitForSeconds(stopTime);
            //this.tag = "MoveStage";
            state = STATE.GO;
        }
       

    }
}
