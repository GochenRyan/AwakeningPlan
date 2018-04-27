using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour {



    public float maxSpeed = 30f;

	//重力加速度
	public float g = 9.8f;

	//阻力减速
	public float f = -3f;

	//初速度
	public float v0 = 0f;

	public float speed = 0f;

    //上次记录的y值 初始值为最开始y值
    float lastY ;


	private MoveNew moveC;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, 0, 0);
		speed = v0;
		moveC = GameObject.Find ("GvrMain").GetComponent<MoveNew> ();

    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {

		//控制速度大小
		if(speed <= maxSpeed)
		{
			speed += Time.deltaTime * g;
		}else{
			speed += Time.deltaTime * f; 
		}

		if(moveC.speed >= moveC.maxSpeed)
		{
			moveC.speed += Time.deltaTime * f;
		}

		transform.Translate (new Vector3(0,-speed * Time.deltaTime,0));
    }
}
