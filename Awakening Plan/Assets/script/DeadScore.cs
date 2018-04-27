using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadScore : MonoBehaviour {

	public GameObject t;

	// Use this for initialization
	void Start () {
		TextMesh text =  t.GetComponent<TextMesh>();
		text.text = "任务失败\n您的分数是: " + MainControl.score;
		MainControl.score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
