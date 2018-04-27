using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gaze : MonoBehaviour
{
    public Image img;
    int mode = 0; //如果选中的话，选择的模式
    string level;   //之前中断的关卡
    public float gazeTime = 0f;  //盯着的时间  
    public float waitTime = 3f;  //盯多久才选中  
    public bool hasChangeMat = false;
    public CanvasGroup cg;
    private Material otherMat;
    public DataController dc;
    // Use this for initialization  
    void Start()
    {
    }
    // Update is called once per frame  
    void Update()
    {
        if (mode != 0)
        {
            cg.alpha += 0.5f * Time.deltaTime;          //画面淡入淡出
        
        if (cg.alpha == 1)                              //加载场景
        {
            if (mode == 1)
                SceneManager.LoadScene("test");
            if(mode==2)
                {
                    if (PlayerPrefs.HasKey("SaveData") == false)
                    {
                        SceneManager.LoadScene("test");
                    }
                        
                    else
                    {
                        DataController.collections = 0;
                        level = PlayerPrefs.GetString("SaveData", "DefaultValue");
                        if (level == "Level1")
                            DataController.shouldCollect = 8;
                        if (level == "Level2")
                            DataController.shouldCollect = 9;
                        if (level == "Level3")
                            DataController.shouldCollect = 7;
                        if (level == "Level4")
                            DataController.shouldCollect = 6;
                        if (level == "Level5")
                            DataController.shouldCollect =10;
                        SceneManager.LoadScene(PlayerPrefs.GetString("SaveData", "DefaultValue"));

                    }
                }
            if(mode==4)
                    Application.Quit();
            if (mode == 10)
                SceneManager.LoadScene("menu");
            if (mode == 11)
                {
                    SceneManager.LoadScene(DataController.lastscene);
                }
            if (mode == 20)
                SceneManager.LoadScene("endless");


                mode = 0;
        }
        }
        else
        {
            //射线检测  
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                MeshRenderer otherRenderer = hitInfo.collider.gameObject.GetComponent<MeshRenderer>();

                if (otherRenderer != null)
                {
                    if (!hasChangeMat)  //如果没有到时间  
                    {
                        gazeTime += Time.deltaTime;  //增加盯着的时间  
                    }
                }
            }
            else
            {
                //otherMat = null;
                gazeTime = 0f;
                hasChangeMat = false;  //退出凝视则重置hasChangeMat  
            }

            //如果盯着的时间>=应该等待的时间，则表示选中  
            if (gazeTime >= waitTime)
            {
                if (hitInfo.transform.CompareTag("mode1"))
                {
                    mode = 1;
                    DataController.shouldCollect = 3;
                }
                else if (hitInfo.transform.name=="continue")
                {
                    mode = 2;
                }
                else if (hitInfo.transform.CompareTag("quit"))
                {
                    mode = 4;
                }
                else if (hitInfo.transform.CompareTag("menu"))
                {
                    DataController.collections = 0;
                    mode = 10;
                }
                else if (hitInfo.transform.CompareTag("again"))
                {
                    DataController.collections = 0;
                    mode = 11;
                }
                if (hitInfo.transform.CompareTag("endless"))
                {
                    mode = 20;
                }
                gazeTime = 0f;
                hasChangeMat = true;

            }
            else
            {
                
                //设置准星形状  
                img.fillAmount = 1 - (gazeTime / waitTime); //设置FillAmount  
            }


        }
    }

}