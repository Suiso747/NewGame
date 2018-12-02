using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Vector3 playerPos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Miss(){
        // ミスした時の処理
        Application.LoadLevel("Tutorial Stage");
        //GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-5f, -1.5f, 0);
    }
}
