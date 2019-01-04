﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip clearME;
    public AudioClip damageSE;
    public Image redImage;

    public GameObject player;
    //Vector3 playerPos;
	// Use this for initialization

    // ゲームステート
    public enum GAME_STATE{
        PLAY,
        CLEAR,
        MISS,
    }
    public GAME_STATE gameState = GAME_STATE.PLAY;

    // 最後にセーブしたセーブポイントのID
    string ID = "SaveID";

    // ミスした回数
    string METROMissCount = "METROMissCount";
    string ELECTRONMissCount = "ELECTRONMissCount";
    string FAIRYMissCount = "FAIRYMissCount";
    string INABAMissCount = "INABAMissCount";

    int missCount = 0;

    // クリアしたステージ
    string TUTORIAL = "TURORIAL";

    string METRO = "METROPOLIS";
    string ELECTRON = "ELECTRON";
    string FAIRY = "FAIRY";
    // TODO ステージ作ったら追加 
    string INABA = "INABA";


    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Miss(){
        // ミスした時の処理
        Scene loadScene = SceneManager.GetActiveScene();
        // ELECTRON STAGEの場合
        if (loadScene.name == "ELECTRON STAGE")
        {
            PlayerPrefs.SetInt(ELECTRONMissCount, PlayerPrefs.GetInt(ELECTRONMissCount, 0) + 1);
            Debug.Log("missCount: " + PlayerPrefs.GetInt(ELECTRONMissCount, 0));
        // METROPOLIS STAGEの場合
        }else if (loadScene.name == "METROPOLIS STAGE"){
            PlayerPrefs.SetInt(METROMissCount, PlayerPrefs.GetInt(METROMissCount, 0) + 1);
            Debug.Log("missCount: " + PlayerPrefs.GetInt(METROMissCount, 0));
        // FAIRYTALE STAGEの場合
        }else if (loadScene.name == "FAIRYTALE STAGE"){
            PlayerPrefs.SetInt(FAIRYMissCount, PlayerPrefs.GetInt(FAIRYMissCount, 0) + 1);
            Debug.Log("missCount: " + PlayerPrefs.GetInt(FAIRYMissCount, 0));           

        // INABA STAGEの場合
        }else if (loadScene.name == "INABA STAGE"){
            PlayerPrefs.SetInt(INABAMissCount, PlayerPrefs.GetInt(INABAMissCount, 0) + 1);
            Debug.Log("missCount: " + PlayerPrefs.GetInt(INABAMissCount, 0));           
        }
        else{
            // TODO TUTORIAL以外の全てのステージ分作る
        }

        gameState = GAME_STATE.MISS;
        audioSource.PlayOneShot(damageSE);

        redImage.color = new Color(0.5f, 0f, 0f, 0.5f);


        StartCoroutine(Restart());


    }

    public void Clear(){
        // クリアした時の処理

       
        gameState = GAME_STATE.CLEAR;
        audioSource.Stop();
        audioSource.PlayOneShot(clearME);
        StartCoroutine(SceneChange());

    }


    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1);
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
        Debug.Log(PlayerPrefs.GetInt(ID));

    }

    // ファンファーレを聞いてシーン遷移
    IEnumerator SceneChange()
    {


        yield return new WaitForSeconds(10);


        PlayerPrefs.SetInt(ID, 0);
        PlayerPrefs.Save();

        Scene loadScene = SceneManager.GetActiveScene();
        // TUTORIAL STAGEの場合
        if (loadScene.name == "TUTORIAL STAGE")
        {
            PlayerPrefs.SetInt(TUTORIAL, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("STAGE SELECT");
        }
        // ELECTRON STAGEの場合
        else if(loadScene.name == "ELECTRON STAGE")
        {
          
            missCount = 0;
            PlayerPrefs.SetInt(ELECTRON, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("STAGE SELECT");
        }
        // METROPORIS STAGEの場合               
        else if (loadScene.name == "METROPOLIS STAGE")
        {
           
            missCount = 0;
            PlayerPrefs.SetInt(METRO, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("STAGE SELECT");

        }
        // FAIRYTALE STAGEの場合               
        else if (loadScene.name == "FAIRYTALE STAGE")
        {
           
            missCount = 0;
            PlayerPrefs.SetInt(FAIRY, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("STAGE SELECT");

        }
        // INABA STAGEの場合               
        else if (loadScene.name == "INABA STAGE")
        {

            missCount = 0;
            PlayerPrefs.SetInt(INABA, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("STAGE SELECT");

        }
        else
        {

            PlayerPrefs.Save();
            SceneManager.LoadScene("TITLE");
        }


        // TODO GAME CENTERへ遷移



    }
}
