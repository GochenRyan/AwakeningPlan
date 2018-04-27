using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControlNew: MonoBehaviour {
	// 6个无尽墙
	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;
	public GameObject wall5;
	public GameObject wall6;

	//第一人称视角y坐标
	private float inity;

	private float wallHeight;

	//上次的y坐标计算速度用
	private float lastY;

	//墙开始移动的底限
	private float moveLimit;



	// Use this for initialization
	void Start () {
		//初始墙的高度
		wallHeight = wall1.transform.localScale.z * wall1.GetComponent<MeshFilter> ().mesh.bounds.size.z;

		//出生位置
		transform.position = new Vector3(transform.position.x,wallHeight - 3000,transform.position.z);

		inity = transform.position.y;
		lastY = transform.position.y;

		moveLimit = 0.1f * wallHeight;

	}


	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{

		float y = transform.position.y;
		float speed = (lastY - y) / Time.deltaTime;
		lastY = y;
		if(inity - transform.position.y > moveLimit ){
			wall1.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
			wall2.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
			wall3.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
			wall4.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
			wall5.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
			wall6.transform.Translate (new Vector3 (0,0,-speed * Time.deltaTime));
		}

	}
}
