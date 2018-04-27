using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressControl : MonoBehaviour {
    public Image img;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = (float)DataController.collections / DataController.shouldCollect  ;             //设置收集图标的填充过程
	}
}
