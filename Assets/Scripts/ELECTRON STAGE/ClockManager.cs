using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{

    public SpriteRenderer sprite;
    AudioSource audioSource;
    public AudioClip switchOnSE;
    public AudioClip switchOffSE;

    public SpriteRenderer blocksSprite;
    public GameObject blocks;
    public GameObject spinBlocks;
    public GameObject walls;
    public GameObject toggleBlocks;
    public GameObject dancingBlocksR;
    public GameObject dancingBlocksB;
    public GameManager gameManager;
    float g, b;
    bool jumpFlagB;
    bool jumpFlagR;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (gameManager.gameState == GameManager.GAME_STATE.CLEAR){
            audioSource.volume = 0;
        }
        /*
            // ユニットが変わったフレームで true になる
            if (Music.IsJustChanged)
            {
   
            }
        */

            // 小節に来たフレームで true になる
            if ( Music.IsJustChangedBar())
            {


                if (Music.Just.Bar % 4 == 1){
                    g = Random.Range(0.6f, 0.95f);
                    b = Random.Range(0.6f, 0.95f);

                    // Imageの色変更
                    DOTween.To(
                            () => sprite.color,                // 何を対象にするのか
                            color => sprite.color = color,    // 値の更新
                            new Color(0, g, b),                    // 最終的な値
                            1.5f                                // アニメーション時間
                    );

                foreach (SpriteRenderer t in blocks.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(0, 0, 0),                    // 最終的な値
                      1.5f                                // アニメーション時間
                    );
                }

                foreach (SpriteRenderer t in walls.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(1,1,1),                    // 最終的な値
                      1.5f                                // アニメーション時間
                    );
                }
                foreach (Transform t in blocks.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOMove(
                        new Vector3(t.position.x, t.position.y - 0.2f, t.position.z),　　//移動後の座標
                        4.0f 　　　　　　//時間
                    );
                }
                foreach (Transform t in walls.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOMove(
                        new Vector3(t.position.x, t.position.y + 0.2f, t.position.z),　　//移動後の座標
                        4.0f 　　　　　　//時間
                    );
                }


                // 回転させるブロック

                foreach (Transform t in spinBlocks.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOLocalRotate(
                        new Vector3(0f, 0f, -90f),   // 終了時点のRotation
                        1.0f                    // アニメーション時間
                    );
                }
                // 青赤の切り替え
                foreach (SpriteRenderer t in toggleBlocks.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    if (t.color.r <= 0.3f){
                        DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(0.855f, 0.255f, 0.215f),                    // 最終的な値
                      0.5f                                // アニメーション時間
                    );
                    }else{
                        DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(0.2f, 0.2f, 1.0f),                    // 最終的な値
                      0.5f                                // アニメーション時間
                    );
                    }

                }
                jumpFlagB = false;
                jumpFlagR = true;
                audioSource.PlayOneShot(switchOnSE);


            }
            else if (Music.Just.Bar % 4 == 3)
                {
      
                    // Imageの色変更
                    DOTween.To(
                            () => sprite.color,                // 何を対象にするのか
                            color => sprite.color = color,    // 値の更新
                            new Color(0, g/4, b/4),                    // 最終的な値
                            1.5f                                // アニメーション時間
                    );
                foreach (SpriteRenderer t in blocks.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(1,1,1),                    // 最終的な値
                      0.2f                                // アニメーション時間
                    );
                }
                foreach (SpriteRenderer t in walls.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                        new Color(0.855f, 0.255f, 0.215f),                    // 最終的な値
                      0.2f                                // アニメーション時間
                    );
                }
                foreach (Transform t in blocks.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOMove(
                        new Vector3(t.position.x, t.position.y + 0.2f, t.position.z),　　//移動後の座標
                        4.0f 　　　　　　//時間
                    );
                }
                foreach (Transform t in walls.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOMove(
                        new Vector3(t.position.x, t.position.y - 0.2f, t.position.z),　　//移動後の座標
                        4.0f 　　　　　　//時間
                    );
                }
                // 回転させるブロック

                foreach (Transform t in spinBlocks.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
                {
                    t.DOLocalRotate(
                        new Vector3(0f, 0f, 90f),   // 終了時点のRotation
                        1.0f                    // アニメーション時間
                    );
                }
                // 青赤の切り替え
                foreach (SpriteRenderer t in toggleBlocks.GetComponentsInChildren<SpriteRenderer>(true)) //include inactive gameobjects
                {
                    if (t.color.r <= 0.3f)
                    {
                        DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(0.855f, 0.255f, 0.215f),                    // 最終的な値
                      0.5f                                // アニメーション時間
                    );
                    }
                    else
                    {
                        DOTween.To(
                      () => t.color,                // 何を対象にするのか
                        color => t.color = color,    // 値の更新
                      new Color(0.2f, 0.2f, 1.0f),                    // 最終的な値
                      0.5f                                // アニメーション時間
                    );
                    }

                }

                jumpFlagB = true;
                jumpFlagR = false;
                audioSource.PlayOneShot(switchOffSE);
            }
        }
       
        // 拍に来たフレームで true になる
        if (Music.IsJustChangedBeat())
        {
            foreach (Transform t in dancingBlocksR.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
            {

                if ( jumpFlagR == true)
                {
                    t.GetComponentInChildren<Transform>().DOLocalJump(
                        t.GetComponentInChildren<Transform>().position,      // 移動終了地点
                        0.7f,               // ジャンプする力
                        1,               // ジャンプする回数
                        0.5f              // アニメーション時間
                    );
                }
                                               
            }
            foreach (Transform t in dancingBlocksB.GetComponentsInChildren<Transform>(true)) //include inactive gameobjects
            {

                if (jumpFlagB == true)
                {
                    t.GetComponentInChildren<Transform>().DOLocalJump(
                        t.GetComponentInChildren<Transform>().position,      // 移動終了地点
                        0.3f,               // ジャンプする力
                        1,               // ジャンプする回数
                        0.5f              // アニメーション時間
                    );
                }

            }

        }
            // 指定した小節、拍、ユニットに来たフレームで true になる
        /*
            if (Music.IsJustChangedAt(1, 2, 3))
            {
            }
            */

        /*
        // 小節に来たフレームで true になる
        if ( Music.IsJustChangedBar() )
        {
            DOTween
                .To( value => OnRotate( value ), 0, 1, 0.5f )
                .SetEase( Ease.OutCubic )
                .OnComplete( () => transform.localEulerAngles = new Vector3( 45, 45, 0 ) )
            ;
        }
        // 拍に来たフレームで true になる
        else if ( Music.IsJustChangedBeat() )
        {
            DOTween
                .To( value => OnScale( value ), 0, 1, 0.1f )
                .SetEase( Ease.InQuad )
                .SetLoops( 2, LoopType.Yoyo )
            ;
        }
        */
    }
    /*
    private void OnScale( float value )
    {
        var scale = Mathf.Lerp( 1, 1.2f, value );
        transform.localScale = new Vector3( scale, scale, scale );
    }

    private void OnRotate( float value )
    {
        var rot = transform.localEulerAngles;
        rot.z = Mathf.Lerp( 0, 360, value );
        transform.localEulerAngles = rot;
    }
    */
}