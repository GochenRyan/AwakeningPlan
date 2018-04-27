using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class LevelLoad : MonoBehaviour {
    public CanvasGroup cg;
    int button=0;

	private Move move;
	// Use this for initialization
	void Start () {
        button = 0;
		move = GameObject.Find("GvrMain").GetComponent<Move>();
    }
	
	// Update is called once per frame
	void Update () {
        if (button == 1)                                //关卡淡出
        {
            cg.alpha += 1f * Time.deltaTime;
        }
        if(cg.alpha>=1f && button==1 && SceneManager.GetActiveScene().name!="Level5")
            SceneManager.LoadScene("pod stage");
        else if (cg.alpha >= 1f && button == 1 && SceneManager.GetActiveScene().name == "Level5")
            SceneManager.LoadScene("final");

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "finish" && DataController.collections >= DataController.shouldCollect)                 //过关条件
        {
            Debug.Log("finish");
            button = 1;
            DataController.lastscene = SceneManager.GetActiveScene().name;
        }
        else if (other.name == "finish" && DataController.collections != DataController.shouldCollect)               //失败条件之没有收集完全
        {
            PlayerPrefs.SetString("SaveData", SceneManager.GetActiveScene().name);
            DataController.lastscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("dead");
        }


		if(other.tag == "boost"){
			move.speedy *= 1.45f;
		}
		if(other.tag == "barrer"){
			move.speedy /= 2;
		}if (other.tag == "destroy") {

			//找到所有的obs
			GameObject[] gosf =  GameObject.FindGameObjectsWithTag (" obs");
			// 障碍物和人的距离

			List<GameObject> gos = new List<GameObject> (gosf); 

			for (int i = 0; i < gos.Count; i++) {
				double des2x = Math.Pow (transform.position.x - gos [i].transform.position.x, 2);
				double des2y = Math.Pow (transform.position.y - gos [i].transform.position.y, 2);
				double des2z = Math.Pow (transform.position.z - gos [i].transform.position.z, 2);
				double des = Math.Pow (des2x + des2y + des2z, 0.5);
				if ( des  < 40) {
					GameObject go = gos [i];
					gos.Remove (gos[i]);
					Destroy (go);
				}

			}

		}



    }
    private void OnCollisionEnter(Collision collision)                              //失败条件之碰到障碍物
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag != "untouched")
        {
            PlayerPrefs.SetString("SaveData", SceneManager.GetActiveScene().name);
            DataController.lastscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("dead");
        }
    }
}
