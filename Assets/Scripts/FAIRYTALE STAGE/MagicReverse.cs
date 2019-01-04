using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// LeftRightが反転
public class MagicReverse : MonoBehaviour
{

    GameObject player;
    public float magicTime = 10.0f;

    AudioSource audioSource;
    public AudioClip magicSE; // SE
    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // 子ルーチン呼び出し
    public void Reverse()
    {
        if(player.GetComponent<FairyPlayerController>().reverse == false){
            StartCoroutine("Magic");
        }

    }

    IEnumerator Magic()
    {
        gameManager.GetComponent<AudioSource>().pitch = 0.95f;
        audioSource.pitch = 2.0f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<FairyPlayerController>().reverse = true;
        player.GetComponent<SpriteRenderer>().color = new Color(1,204/255f,25/255f);
        yield return new WaitForSeconds(magicTime);

        gameManager.GetComponent<AudioSource>().pitch = 1.0f;
        audioSource.pitch = 3.0f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<SpriteRenderer>().color = new Color(1, 204 / 255f, 1);
        player.GetComponent<FairyPlayerController>().reverse = false;

    }

}
