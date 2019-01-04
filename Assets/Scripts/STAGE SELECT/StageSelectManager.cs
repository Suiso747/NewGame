using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour {

    // セレクト画面のステージ回転中心
	public GameObject stagePivot;


    // 選択しているステージ
    public enum SELECT_STAGE
    {
        ELECTRON,
        METRO,
        FAIRY,
        INABA, // (仮のステージ名)
        TEST4,
        TEST5,
	}
    SELECT_STAGE selectedStage = SELECT_STAGE.ELECTRON;
    bool canRotate = true;

    AudioSource audioSource;
    public AudioClip rotateSE;
    public AudioClip startSE;

    public TextMeshProUGUI stageText;
    public GameObject commenter;
    public GameObject commenterName;
    public Text commentText;

    public GameObject ELECTRONDisplay;
    public GameObject METRODisplay;
    public GameObject FAIRYDisplay;
    public GameObject INABADisplay;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        ShowStageName();
    }
	
	// Update is called once per frame
	void Update () {

 


//        float x = Input.GetAxisRaw("Horizontal"); // キーボードの左右を押しているか
		float y = Input.GetAxisRaw("Vertical"); // キーボードの上下を押しているか

        if (canRotate){
            if (y > 0 || y < 0){
                ELECTRONDisplay.SetActive(false);
                METRODisplay.SetActive(false);
                FAIRYDisplay.SetActive(false);
                INABADisplay.SetActive(false);
            }

            if (y < 0)
            {
                StartCoroutine("RotateStageL");
            }
            else if (y > 0)
            {
                StartCoroutine("RotateStageR");
            }
            // 決定
            if (Input.GetKeyDown("space"))
            {
                StartStage();

            }

        }

    }
    IEnumerator RotateStageL(){

        canRotate = false;
        audioSource.PlayOneShot(rotateSE);

        if (selectedStage == SELECT_STAGE.TEST5)
        {
            selectedStage = SELECT_STAGE.ELECTRON;
        }
        else
        {
            selectedStage++;
        }
        yield return new WaitForSeconds(0.1f);

        stagePivot.transform.DORotate(
                new Vector3(0f, 0f, (int)selectedStage * 60),   // 終了時点のRotation
            0.1f                    // アニメーション時間
            );

        canRotate = true;
        ShowStageName();
    }
    IEnumerator RotateStageR()
    {

        canRotate = false;
        audioSource.PlayOneShot(rotateSE);
        if (selectedStage == SELECT_STAGE.ELECTRON)
        {
            selectedStage = SELECT_STAGE.TEST5;
        }
        else
        {
            selectedStage--;
        }
        yield return new WaitForSeconds(0.1f);

        stagePivot.transform.DORotate(
                new Vector3(0f, 0f, (int)selectedStage * 60),   // 終了時点のRotation
            0.1f                    // アニメーション時間
            );

        canRotate = true;
        ShowStageName(); 
    }

    void ShowStageName(){

        switch (selectedStage)
        {
            case SELECT_STAGE.ELECTRON:
                stageText.text = "ELECTRON STAGE";
                ELECTRONDisplay.SetActive(true);
                if (PlayerPrefs.GetInt("ELECTRON")==1){
                    commenter.SetActive(true);
                    commenterName.SetActive(true);


                    int missCount = PlayerPrefs.GetInt("ELECTRONMissCount");
                    if (missCount == 0)
                    {
                        commentText.text = "↑落ち着いてやればノーミス余裕だよ";
                    }
                    else if (missCount <= 8)
                    {
                        commentText.text = missCount + "回ミスったけどクリア！";
                    }
                    else if (missCount <= 30)
                    {
                        commentText.text = missCount + "円返せ";
                    }
                    else
                    {
                        commentText.text = "僕のコンティニュー回数超えられるやついる？多分" + missCount + "回";
                    }
                   
                }else{
                    commenter.SetActive(false);
                    commenterName.SetActive(false);
                    commentText.text = "";
                }
                break;
            case SELECT_STAGE.METRO:
                stageText.text = "METROPOLIS STAGE";
                METRODisplay.SetActive(true);
                if (PlayerPrefs.GetInt("METROPOLIS") == 1)
                {
                    commenter.SetActive(true);
                    commenterName.SetActive(true);

                    int missCount = PlayerPrefs.GetInt("METROMissCount");
                    if (missCount == 0)
                    {
                        commentText.text = "ノーミス余裕wwwwwwwwwwwwwwwwwwwwwwwww";
                    }
                    else if (missCount <= 8)
                    {
                        commentText.text = "本日の交通事故 " +missCount + "件";
                    }
                    else if (missCount <= 30)
                    {
                        commentText.text = missCount + "円返せ";
                    }
                    else
                    {
                        commentText.text = "僕のコンティニュー回数超えられるやついる？多分" + missCount + "回";
                    }

                }
                else
                {
                    commenter.SetActive(false);
                    commenterName.SetActive(false);
                    commentText.text = "";
                }
                break;
            case SELECT_STAGE.FAIRY:
                stageText.text = "FAIRYTALE STAGE";
                FAIRYDisplay.SetActive(true);
                if (PlayerPrefs.GetInt("FAIRY") == 1)
                {
                    commenter.SetActive(true);
                    commenterName.SetActive(true);

                    int missCount = PlayerPrefs.GetInt("FAIRYMissCount");
                    if (missCount == 0)
                    {
                        commentText.text = "童話のような優しさでしたね";
                    }
                    else if (missCount <= 8)
                    {
                        commentText.text = missCount +"体のピンク玉が...";
                    }
                    else if (missCount <= 30)
                    {
                        commentText.text = missCount + "円返せ";
                    }
                    else
                    {
                        commentText.text = "僕のコンティニュー回数超えられるやついる？多分" + missCount + "回";
                    }

                }
                else
                {
                    commenter.SetActive(false);
                    commenterName.SetActive(false);
                    commentText.text = "";
                }
                break;

            // ここ編集して
            case SELECT_STAGE.INABA:
                stageText.text = "INABA STAGE";
                INABADisplay.SetActive(true);
                if (PlayerPrefs.GetInt("INABA") == 1)
                {
                    commenter.SetActive(true);
                    commenterName.SetActive(true);

                    int missCount = PlayerPrefs.GetInt("INABAMissCount");
                    if (missCount == 0)
                    {
                        commentText.text = "粋の境地とはこのことか...";
                    }
                    else if (missCount <= 8)
                    {
                        commentText.text = "よかった、これで解決ですね";
                    }
                    else if (missCount <= 30)
                    {
                        commentText.text = missCount + "00円も使うなんて穏やかじゃないですね";
                    }
                    else
                    {
                        commentText.text = "僕のコンティニュー回数超えられるやついる？多分" + missCount + "回";
                    }

                }
                else
                {
                    commenter.SetActive(false);
                    commenterName.SetActive(false);
                    commentText.text = "";
                }
                break;
            default:
                stageText.text = "??? STAGE (now => TITLE)";
                if (PlayerPrefs.GetInt("????") == 1)
                {
                    commenter.SetActive(true);
                    commenterName.SetActive(true);
                   
                }
                else
                {
                    commenter.SetActive(false);
                    commenterName.SetActive(false);
                    commentText.text = "";
                }
                break;

        }


    }

    void StartStage(){
        audioSource.PlayOneShot(startSE);

        PlayerPrefs.SetInt("SaveID", 0);
        // クリアしていないステージにのみ遷移
        switch (selectedStage)
        {
            case SELECT_STAGE.ELECTRON:
                if (PlayerPrefs.GetInt("ELECTRON") != 1){
                    SceneManager.LoadScene("ELECTRON STAGE");
                }

                break;
            case SELECT_STAGE.METRO:
                if (PlayerPrefs.GetInt("METROPOLIS") != 1)
                {
                    SceneManager.LoadScene("METROPOLIS STAGE");
                }

                break;
            case SELECT_STAGE.FAIRY:
                if (PlayerPrefs.GetInt("FAIRY") != 1)
                {
                    SceneManager.LoadScene("FAIRYTALE STAGE");
                }
                break;
            case SELECT_STAGE.INABA:
                if (PlayerPrefs.GetInt("INABA") != 1)
                {
                    SceneManager.LoadScene("INABA STAGE");
                }

                break;
            default:
                SceneManager.LoadScene("TITLE");
                break;

        }
    }
}
