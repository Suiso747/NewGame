using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    Vector3 playerPos;
    public Text messageText;
    

	// Use this for initialization
	void Start () {
        //playerPos = GameObject.Find("Player").transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        playerPos = GameObject.Find("Player").transform.position;

        if (playerPos.x <= 5){
            messageText.text = "十字キー[←][→]で移動\n" +
                "スペース[SPACE]でジャンプだ";
        }
        else if (playerPos.x <= 12)
        {
            messageText.text = "赤いモノには当たってはいけないよ\n" +
                "スペース[SPACE]でかわそう！";
        }
        else if (playerPos.x <= 24) 
        {
            messageText.text = "灰色のブロックは重力に従うよ！\n" +
                 "体当たりしてみよう！";
        } 
        else 
        {
            messageText.text = "黄色がゴールだ！(現在ここまで)";
        }
    
    }
}
