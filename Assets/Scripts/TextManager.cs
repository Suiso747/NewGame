using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    Vector3 playerPos;
    public Text messageText;

    public AudioClip textSE;
    AudioSource audioSource;

    public bool[] isReadText = new bool[4]; // テキストがどこまで進行したかを管理

	// Use this for initialization
	void Start () {
        //playerPos = GameObject.Find("Player").transform.position;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        playerPos = GameObject.Find("Player").transform.position;

        if (playerPos.x <= 5){
            messageText.text = "十字キー[←][→]で移動\n" +
                "スペース[SPACE]でジャンプだ";
        }
        else if (playerPos.x <= 12)
        {          
           
            messageText.text = "赤いモノには当たってはいけないよ\n" +
                "スペース[SPACE]でかわそう！";
            if (isReadText[0] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[0] = true;
            }
        }
        else if (playerPos.x <= 24) 
        {


            messageText.text = "灰色のブロックは重力に従うよ！\n" +
                 "体当たりしてみよう！";
            if (isReadText[1] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[1] = true;
            }
        } 
        else 
        {
        
            messageText.text = "黄色がゴールだ！(現在ここまで)";
            if (isReadText[2] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[2] = true;
            }
        }
    
    }
}
