using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmExample : MonoBehaviour
{

    public SpriteRenderer sprite;
    AudioSource audioSource;
    public AudioClip switchSE;

    public GameObject clockManager;
    Music music;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        music = clockManager.GetComponent<Music>();
    }

    private void Update()
    {
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
                    float g = Random.Range(0.6f, 0.95f);
                    float b = Random.Range(0.6f, 0.95f);

                    // Imageの色変更
                    DOTween.To(
                            () => sprite.color,                // 何を対象にするのか
                            color => sprite.color = color,    // 値の更新
                            new Color(0, g, b),                    // 最終的な値
                            2f                                // アニメーション時間
                    );

                } else if (Music.Just.Bar % 4 == 3)
                {
                    float g = Random.Range(0.15f, 0.2f);
                    float b = Random.Range(0.15f, 0.2f);

                    // Imageの色変更
                    DOTween.To(
                            () => sprite.color,                // 何を対象にするのか
                            color => sprite.color = color,    // 値の更新
                            new Color(0, g, b),                    // 最終的な値
                            2f                                // アニメーション時間
                    );
             }
        }
       
        // 拍に来たフレームで true になる
        if (Music.IsJustChangedBeat())
        {
            audioSource.PlayOneShot(switchSE);


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