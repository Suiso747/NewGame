using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// LeftRightが反転
public class Magicreverse : MonoBehaviour
{

    GameObject player;
    public float magicTime = 10.0f;

    AudioSource audioSource;
    public AudioClip magicSE; // SE


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // 子ルーチン呼び出し
    void SpeedUp()
    {

        StartCoroutine("Magic");
    }

    IEnumerator Magic()
    {
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<PlayerController>().reverse = true;
        yield return new WaitForSeconds(magicTime);
        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<PlayerController>().reverse = false;

    }

}
