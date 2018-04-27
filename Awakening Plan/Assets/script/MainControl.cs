using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour {

	//分数
	public static long score = 0;

	//初始y坐标
	private float initY;

	private long count;


	private SpeedControl speedC;

	private ObstacleControl obsC;
	 
	private MoveNew moveC;

	private float getSpeed(){
		return speedC.speed;
	}

	// Use this for initialization
	void Start () {
		initY = transform.position.y;
		speedC = GameObject.Find ("GvrMain").GetComponent<SpeedControl>();
		obsC = GameObject.Find ("GvrMain").GetComponent<ObstacleControl>();
		moveC = GameObject.Find ("GvrMain").GetComponent<MoveNew> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){

		//速度占 0.02
		score +=(long) (getSpeed() * 0.02f);

		count +=(long) (getSpeed() * 0.02f);

		if (count > 10000) {
			count -= 10000;
			obsC.lLimit++;
			obsC.hLimit++;
			speedC.maxSpeed+=10;
		}


	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "wall" || other.tag == " obs") {
			SceneManager.LoadScene("deadendless");
		} else if (other.tag == "boost") {
			speedC.speed *= 1.35f;
			moveC.speed *= 1.5f;
		} else if (other.tag == "barrer") {
			speedC.speed /= 3;
			//重力加速的减小
			speedC.g = 2f;
		} else if (other.tag == "destroy") {
			obsC.bong ();
		}
	}

	void OnTriggerStay(Collider other){


	}

	void OnTriggerExit(Collider other){


	}
}
