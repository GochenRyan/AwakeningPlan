using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
    public static int collections;                  //当前场景的收集要素
    public static string lastscene;                 //上一个场景
    public static int shouldCollect;                //当前场景总共的
	// Use this for initialization
	void Start () {
       // GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(collections);
	}
}
