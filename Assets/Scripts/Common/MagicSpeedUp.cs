using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// moveSpeedが上昇
public class MagicSpeedUp : MonoBehaviour {

    GameObject player;
    public float speedUpRate = 3.0f;
    public float magicTime = 5.0f;

    AudioSource audioSource;
    public AudioClip magicSE; // SE


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
	}	

    // 子ルーチン呼び出し
    void SpeedUp(){

        StartCoroutine("Magic");
    }

    IEnumerator Magic()
    {
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<PlayerController>().speedRate = speedUpRate;
        yield return new WaitForSeconds(magicTime);
        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<PlayerController>().speedRate = 1.0f;

    }

}
