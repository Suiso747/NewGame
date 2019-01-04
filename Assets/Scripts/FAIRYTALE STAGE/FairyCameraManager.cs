using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyCameraManager : MonoBehaviour {

    GameObject player;
    Vector3 cameraPos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーをカメラが追いかける(x軸方向のみ変動)
        if (player != null)
        {
            Vector3 cameraPos = new Vector3(player.transform.position.x,
                                            transform.position.y,
                                            transform.position.z);
            if (cameraPos.x < 0.0f)
            {
                cameraPos.x = 0.0f;
            }
            if (cameraPos.x > 180f)
            {
                cameraPos.x = 180f;
            }

            transform.position = cameraPos;
        }
    }
}
