using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip clearME;
    public AudioClip damageSE;

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

        StartCoroutine(Example());


    }

    public void Clear(){
        // クリアした時の処理
        gameState = GAME_STATE.CLEAR;
        audioSource.Stop();

        audioSource.PlayOneShot(clearME);
    }


    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Tutorial Stage");
        print(Time.time);
    }
}
