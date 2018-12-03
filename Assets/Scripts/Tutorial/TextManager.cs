using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    Vector3 playerPos;
    public Text messageText;

    public AudioClip textSE;
    AudioSource audioSource;

    bool[] isReadText = new bool[10]; // チュートリアルのテキストがどこまで進行したかを管理

    public SpriteRenderer building;// 少しずつ背景の街並みが現れる演出用
    float alpha; // アルファ値 0が透明

	// Use this for initialization
	void Start () {
        //playerPos = GameObject.Find("Player").transform.position;
        audioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (playerPos.x > 60){
            alpha = (playerPos.x -60) / 10f;
        }else{
            alpha = 0;
        }

        building.color = new Color(1, 1, 1, alpha);
    }

    // Update is called once per frame
    void FixedUpdate () {

        playerPos = GameObject.Find("Player").transform.position;

        if (playerPos.x <= 5)
        {
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
        else if (playerPos.x <= 34)
        {

            messageText.text = "洞窟だ！くれぐれも「赤いモノ」に注意しよう！";
            if (isReadText[2] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[2] = true;
            }
        }
        else if (playerPos.x <= 40)
        {

            messageText.text = "ぷかぷか〜♪(´ε｀ )";
            if (isReadText[3] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[3] = true;
            }
        }
        else if (playerPos.x <= 46)
        {

            messageText.text = "そういえば、今日は何の日かわかる？";
            if (isReadText[4] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[4] = true;
            }
        }
        else if (playerPos.x <= 52)
        {

            messageText.text = "そう！彼女の誕生日だったね！" +
                "今から街へプレゼントを買いに行くんだったね！";
            if (isReadText[5] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[5] = true;
            }
        }
        else if (playerPos.x <= 68)
        {

            messageText.text = "もうすぐ街だよ！" +
                "何を買おうかな〜！";
            if (isReadText[6] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[6] = true;
            }
        }
        else{
            messageText.text = "黄色の光がゴールだ！";
            if (isReadText[7] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[7] = true;
            }
        }

    }
}
