using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetroTextManager : MonoBehaviour
{

    Vector3 playerPos;
    public Text messageText;

    public AudioClip textSE;
    AudioSource audioSource;

    bool[] isReadText = new bool[10]; // テキストがどこまで進行したかを管理

  
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (GetComponent<GameManager>().gameState == GameManager.GAME_STATE.PLAY)
        {
            playerPos = GameObject.Find("Player").transform.position;

        }

        if (playerPos.x <= 20)
        {
            messageText.text = "都会はクルマが多いぞ！" +
                "赤いクルマには要注意だ！";
        }
        else if (playerPos.x <= 32)
        {

            messageText.text = "道中のコインはゲームセンターで使えるぞ！" +
                "臆することなく拾っていこう(^ ^)";
            if (isReadText[0] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[0] = true;
            }
        }
        else
        {
            messageText.text = "旗がセーブ地点だ！";
            if (isReadText[1] == false)
            {
                audioSource.PlayOneShot(textSE);
                isReadText[1] = true;
            }
        }

    }
}
