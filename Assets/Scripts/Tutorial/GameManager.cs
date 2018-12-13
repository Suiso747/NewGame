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

    // 最後にセーブしたセーブポイントのIDと座標
    string ID = "SaveID";
    //string X = "SaveX";
    //string Y = "SaveY";


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

        // TUTORIAL STAGEの場合
        SceneManager.LoadScene("METROPOLIS STAGE");

        // METROPORIS STAGEの場合

        // TODO GAME CENTERへ遷移

        // それ以外の場合
        
        // TODO GAME CENTERへ遷移



    }
}
