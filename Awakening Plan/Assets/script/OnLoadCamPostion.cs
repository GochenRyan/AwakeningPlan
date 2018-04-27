using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadCamPostion : MonoBehaviour {
    public DataController dc;    //上个场景传来的值
    public StoryController sc;  //控制故事推进
    public CanvasGroup cg;      //控制淡入淡出
    public GameObject cam;
    // Use this for initialization
    void Start () {
        //Debug.Log(dc.collections);
        if(DataController.lastscene=="Level1")                          //判断摄像机要到的位置
        {
            cam.transform.position = new Vector3(24, 4, -85);
        }
        else if (DataController.lastscene == "Level2")
        {
            cam.transform.position = new Vector3(-84, -25, -55);
        }
        else if (DataController.lastscene == "Level3")
        {
            cam.transform.position = new Vector3(-45, 18, 55);
        }
        else if (DataController.lastscene == "Level4")
        {
            cam.transform.position = new Vector3(-84, -25, -55);
        }
        sc.setCollections();                                        //准备对话框
    }
	
	// Update is called once per frame
	void Update () {
        cg.alpha -= 0.1f * Time.deltaTime;
    }
}
