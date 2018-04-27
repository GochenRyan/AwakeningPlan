using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yanjiang : MonoBehaviour {
    public Material m;
    private float x,y;  //设定岩浆的偏移值
	// Use this for initialization
	void Start () {
        x = 0;
        y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        x -= 0.1f * Time.deltaTime;
        y -= 0.1f * Time.deltaTime;
        m.SetTextureOffset("_MainTex", new Vector2(x, y));
	}
}
