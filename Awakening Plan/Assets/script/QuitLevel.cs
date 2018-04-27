using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuitLevel : MonoBehaviour {
    public CanvasGroup cg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cg.alpha += 0.3f * Time.deltaTime;
        if (cg.alpha >= 1f)
            quit();
    }

    public void quit()
    {
        if (DataController.lastscene == "test")
            SceneManager.LoadScene("Level1");
        else if (DataController.lastscene == "Level1")
            SceneManager.LoadScene("Level2");
        else if (DataController.lastscene == "Level2")
            SceneManager.LoadScene("Level3");
        else if (DataController.lastscene == "Level3")
            SceneManager.LoadScene("Level4");
        else if (DataController.lastscene == "Level4")
            SceneManager.LoadScene("Level5");
        else if (DataController.lastscene == "Level5")
            SceneManager.LoadScene("success");
    }
}
