using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public Image logo;
    // クリアしたステージ
    string TUTORIAL = "TURORIAL";

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
        // セーブデータ全消去
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("TUTORIAL STAGE");
    }



    // メニューからContinueを選んだ場合の処理
    public void Continue()
    {
        Debug.Log("Continue");

        // TUTORIALをクリアしている場合
        if(PlayerPrefs.GetInt(TUTORIAL) == 1){
            SceneManager.LoadScene("STAGE SELECT");
        }else{
            // それ以外、TUTORIALから
            Debug.Log("There is no save data");
            //SceneManager.LoadScene("TUTORIAL STAGE");
        }

    }


}
