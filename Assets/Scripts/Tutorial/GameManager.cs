using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip clearME;
    public AudioClip damageSE;
    public Image redImage;

    Vector3 playerPos;
	// Use this for initialization

    // ゲームステート
    public enum GAME_STATE{
        PLAY,
        CLEAR,
        MISS,
    }
    public GAME_STATE gameState = GAME_STATE.PLAY;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Miss(){
        // ミスした時の処理

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
        SceneManager.LoadScene("Tutorial Stage");
    }

    // ファンファーレを聞いて次のシーンへ
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("City");


    }
}
