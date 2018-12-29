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
        TEST1,
        TEST2,
        TEST3,
        TEST4,
        TEST5,
	}
    SELECT_STAGE selectedStage = SELECT_STAGE.ELECTRON;
    bool canRotate = true;

    AudioSource audioSource;
    public AudioClip rotateSE;
    public AudioClip startSE;

    public TextMeshProUGUI stageText;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        ShowStageName();
    }
	
	// Update is called once per frame
	void Update () {

 


        float x = Input.GetAxisRaw("Horizontal"); // キーボードの左右を押しているか
		float y = Input.GetAxisRaw("Vertical"); // キーボードの上下を押しているか

        if (canRotate){
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
                break;
            default:
                stageText.text = "??? STAGE (now => TITLE)";
                break;

        }
    }

    void StartStage(){
        audioSource.PlayOneShot(startSE);

        // TODO クリアしていないステージにのみ遷移
        switch (selectedStage)
        {
            case SELECT_STAGE.ELECTRON:
                SceneManager.LoadScene("ELECTRON STAGE");
                break;
            default:
                SceneManager.LoadScene("TITLE");
                break;

        }
    }
}
