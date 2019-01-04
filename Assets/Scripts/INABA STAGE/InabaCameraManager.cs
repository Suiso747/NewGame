using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InabaCameraManager : MonoBehaviour
{

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
        // プレイヤーをカメラが追いかける(x軸方向のみ変動)、もちろんy軸方向変動できるようにしても良い
        if (player != null)
        {
            Vector3 cameraPos = new Vector3(player.transform.position.x,
                                            transform.position.y,
                                            transform.position.z);
            // ここの値を調整するとカメラの動く範囲が調整可能
            if (cameraPos.x < 0.0f)
            {
                cameraPos.x = 0.0f;
            }
            if (cameraPos.x > 255f)
            {
                cameraPos.x = 255f;
            }

            transform.position = cameraPos;
        }
    }
}
