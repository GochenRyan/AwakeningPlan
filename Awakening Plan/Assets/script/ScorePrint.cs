using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour {

	// 间隔时间  
	private float letterPause = 0f;

	public AudioClip clip;
	Text txt;
	private AudioSource source;


	private long score = 0;

	private readonly Color blue;


	private MainControl main;

	void Start()
	{
		source = GetComponent<AudioSource>();
		txt = GameObject.Find("Text").GetComponent<Text>();
		main = GameObject.Find ("GvrMain").GetComponent<MainControl>();
		StartCoroutine(TypeText());
	}

	void OnGUI()
	{
		// GUI.Label(new Rect(100, 100, 200, 200), "text show");
		GUIStyle bb = new GUIStyle();
		//bb.normal.background = null;    //这是设置背景填充的
		//bb.normal.textColor = new Color(1, 0, 0);   //设置字体颜色的
		bb.fontSize = 40;       //当然，这是字体大小
		bb.wordWrap = true;
		//GUI.Label(new Rect(50, 50, 400, 400), text,bb);
	}

	private IEnumerator TypeText()
	{

		txt.text = "分数: " + MainControl.score;
		yield return new WaitForSeconds(letterPause);

	}

	void FixedUpdate(){
		StartCoroutine(TypeText());
	}
}
