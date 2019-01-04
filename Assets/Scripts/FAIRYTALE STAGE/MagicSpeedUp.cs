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
    public GameManager gameManager;


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
	}	

    // 子ルーチン呼び出し
    public void SpeedUp(){
        if(player.GetComponent<FairyPlayerController>().speedRate<1.01f || player.GetComponent<FairyPlayerController>().speedRate> 0.99f){
            StartCoroutine("Magic");
        }
       
    }

    IEnumerator Magic()
    {
        gameManager.GetComponent<AudioSource>().pitch = 1.1f;
        audioSource.pitch = 2.0f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<FairyPlayerController>().speedRate = speedUpRate;
        player.GetComponent<SpriteRenderer>().color = new Color(140/255f, 1f, 1f);
        yield return new WaitForSeconds(magicTime);


        gameManager.GetComponent<AudioSource>().pitch = 1.0f;
        audioSource.pitch = 3.0f;
        audioSource.PlayOneShot(magicSE);
        player.GetComponent<SpriteRenderer>().color = new Color(1, 204 / 255f, 1);
        player.GetComponent<FairyPlayerController>().speedRate = 1.0f;

     

    }

}
