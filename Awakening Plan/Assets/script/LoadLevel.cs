using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public CanvasGroup cg;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("SaveData",SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "final")
            GameObject.Find("StoryController").GetComponent<StoryController>().setCollections();

    }
	
	// Update is called once per frame
	void Update () {
        cg.alpha -= 0.5f * Time.deltaTime;              //关卡加载后淡入
        if (cg.alpha <= 0f)
            this.enabled = false;
	}
}
