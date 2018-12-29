using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public Image logo;
    // クリアしたステージ
    string STAGE1 = "TURORIAL";
    string STAGE2 = "METROPOLIS";
    string STAGE3 = "ELECTRON";

    // Use this for initialization
    void Start()
    {
        StartCoroutine("TitleLogo");
    }

    IEnumerator TitleLogo()
    {

        yield return new WaitForSeconds(1.0f);
        Destroy(logo, 1.0f);
    }

    // メニューからNewGameを選んだ場合の処理
    public void NewGame(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("TUTORIAL STAGE");
    }



    // メニューからNewGameを選んだ場合の処理
    public void Continue()
    {
        Debug.Log("Continue");

        // METROPOLISをクリアしている場合
        if (PlayerPrefs.GetInt(STAGE2)==1){
            SceneManager.LoadScene("STAGE SELECT");// 拠点

        }
        // TUTORIALをクリアしている場合
        else if(PlayerPrefs.GetInt(STAGE1) == 1){
            SceneManager.LoadScene("METROPOLIS STAGE");
        }else{
            // それ以外、TUTORIALから
            SceneManager.LoadScene("TUTORIAL STAGE");
        }

    }


}
