using UnityEngine;
using System.Collections;
// using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {
	float moveSpeed = 2.0f;
	Rigidbody rb;
	/*publicで変数宣言すると、インスペクタ上に項目が表示される。
	ここではcoinという変数がインスペクタ上で表示される
	 */
	public GameObject coin;
	// Use this for initialization

	/*
	 シーンに置いたLeft Wall,Right Wallをこのスクリプトで使用する。
	 また、それぞれのx座標の変数も準備しておく。
	 */
	public GameObject leftWall;
	public GameObject rightWall;
	float leftWallPositionX;
	float rightWallPositionX;

	void Start () {
		//スクリプトを付けたゲームオブジェクトのrigidbodyコンポーネントを取得する
		rb = this.GetComponent<Rigidbody>();
		//追加：leftWallとrightWallのx座標を取得
		leftWallPositionX = leftWall.transform.position.x;
		rightWallPositionX = rightWall.transform.position.x;

		/*
		scoreText内にあるScoreScriptをgetComponentで取ってくる。
		これで、ScoreScript内にてpublicで宣言した関数を利用できるようになる */
		// scoreS = scoreText.GetComponent<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentPosition = this.transform.position;
		currentPosition.x = Mathf.Clamp(currentPosition.x,
										leftWallPositionX,
										rightWallPositionX);
		this.transform.position = currentPosition;
		/*
		inputクラスは入力システムに関する関数が含まれている
		GetAxisでPCの矢印キーの入力を受け付けることができる
		"Horizontal"だと、左右の矢印キーの入力を受け付け、"Vertical"だと
http://docs.unity3d.com/ja/current/ScriptReference/Input.GetAxis.html
		上下の矢印キーの入力を受け付けるようになる */
		float x = Input.GetAxis("Horizontal");
		//キー入力された際の移動する向きを決める
		//今回はx軸方向に移動させたい
		Vector3 direction = new Vector3(x,0,0);
		//velocity(速度)に代入することによって、このオブジェクトの移動速度が決定される
		rb.velocity = direction * moveSpeed;
		
		/*追加
		スペースキーが押されたときにcoinを生成する。
		第一引数は生成するオブジェクト、第二引数は生成する場所、
		第三引数は生成する角度
		 */
		if(Input.GetKeyDown("space")){
			 Instantiate(coin,this.transform.position,this.transform.rotation);
		 }
	}
}
