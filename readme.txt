1. プロジェクトのフォルダについて
UnityのGUI上で使用するフォルダで、主に使用するのはPrefabs,Resources,Scenes, Scriptsの4つ
Prefabは知っての通り、Resourcesはアニメーションや画像素材、音楽を管理している。Scenesは各Sceneを、Scriptsでは各Sceneごとのソースコードを管理している。 

2. 色々考えたけど、今回はINABA STAGEというサンプルシーンを作って、それをベースにステージを作ってもらう(2つくらい、よければもっと)

3. Scenesフォルダ直下にINABA STAGEというSceneがあるので、ダブルクリック(名前は適当に変えて)

4. Layoutは2by3がおすすめ、Gameビューの画面サイズはStandalone1024*768に設定

5. INABA STAGEの中にあるオブジェクトについて説明
Main Cameraはプレイヤーを映しているカメラ、アタッチしているソース(InabaCameraController)で、カメラの動く範囲をカスタマイズ可能。

6. GameManagerはゲームのステート状態(クリア、プレイ、ミスなど)やセーブロード、シーン遷移等を管理
GameManagerのソースコードは全てのシーンで共通
AudioSourceがアタッチしており、AudioClipからゲームBGMを変更可

7. Player(名前変更不可)は、キーボードで動かすオブジェクトの対象
InabaPlayerControllerで挙動に関して色々カスタマイズができる。ジャンプや着地の音も変更可

8. BackGroundは背景、SpriteRendererのSpriteに画像を入れて、大きさを調整
描画順に注意 Order in Layerの値が小さいほど先に描画される

9. ステージに設置するオブジェクトの数々(当たり判定などプレイヤーとの干渉が大きいものはこちら)
基本、SpriteRendererとColliderの2つ
Sneneビュー上でVを押しながらドラックすると上手く配置できる(コツがいるが)

10. 赤色のオブジェクト
Sprite RendererのColorを(217,66,54)にする
衝突判定はSpriteの形に合わせてbox collider2Dやcircle collider2Dなどを適切に選んで微調整する
ColliderのTriggerをOnにするとすり抜ける(その間TriggerがOnになる)

11. 使用頻度が高いオブジェクトなど
Prehab化しましょう Prefab/INABA STAGEにドラッグ&ドロップ

12. 落下するオブジェクト
RididBody2DとFallNeedleスクリプトをアタッチし、RididBodyのGravityScaleを0にする
FallNeedleでベクトルやスピード、範囲、効果音を指定可能。効果音を付ける場合はAudioSourceもアタッチする
ワールド座標ではなく、ローカルのTransform.positionで判定するので、親オブジェクトの座標を0にすることに注意

14. FlagはSavePointスクリプトの中のIDでセーブを管理する(PlayerPrefsを使用)
0以外の値を入れると、最後に通過したFlagのID,座標をメモリに書き込み、その座標からいつでも再開できる

15. Goalはtagにgoalを指定することでInabaPlayerControllerで分岐処理される

16. OutFlameはいわゆる見えない壁
下側は奈落の底(=ミス)

17. EventSystemは無視でok(消さないこと)

18. Unityはよく落ちるので保存頻度高めに

19. STAGE SELECT, INABA STAGE以外のシーンについてはまだいじらないで

20. STAGE SELECTは、Centerの子オブジェクトMonitor4がINABA STAGEに対応 (画像入れといて)

21. 素材の入手について説明
著作権フリーで(著作元はスタッフクレジットに載せることもあるので覚えておいて)
画像やBGMなどの素材はResourceフォルダに入れるけど、今回はInabaフォルダの下に入れといて(あとで統合しとく)

22. Sneneの移動
基本は、STAGE SELECTシーンでINABA STAGEを選択 => INABA STAGEで遊び、クリア => クリアフラグをONにし、INABA STAGEに戻るという流れ
* STAGE SELECTシーンの、StageSelectManagerスクリプトの21,40, 63, 236~269,318~319および、
GameManagerスクリプトの34, 45, 74~78, 165~172
"<---> STAGE"の<--->をINABAにしているので、フォルダ名やScene名共にステージ名が決まったら変更しといて

23. わからないことがあったら聞いて
