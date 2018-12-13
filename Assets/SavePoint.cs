using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {

    // 最後にセーブしたセーブポイントのIDと座標
    string ID = "SaveID";
    string X = "SaveX";
    string Y = "SaveY";


    public int SAVE_ID;

    public GameObject check;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt(ID, 0)==SAVE_ID)
        {
            check.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(){
    
        check.SetActive(true);
        PlayerPrefs.SetInt(ID, SAVE_ID);
        PlayerPrefs.SetFloat(X, this.transform.position.x);
        PlayerPrefs.SetFloat(Y, this.transform.position.y);

        PlayerPrefs.Save();
        Debug.Log("SaveID: " + PlayerPrefs.GetInt(ID));
    }
}
