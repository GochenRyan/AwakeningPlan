using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour {
    public float speed = 5f;
    Vector3 h = new Vector3();
    public DataController dc;
    // Use this for initialization
    public MoveByMouse mbm;

	public float maxSpeed = 40f;

	//重力加速度
	public float g = 3f;

	//阻力减速
	public float f = -3f;

	//初速度
	public float v0 = 0f;

	//垂直方向上的速度
	public float speedy = 0f;


	public static bool jduge = false;

    //传送阵
    private GameObject send;


    void Start () {

		//取消重力
		Physics.gravity = new Vector3 (0, 0, 0);
        send = GameObject.Find("finish");
    }
	
	// Update is called once per frame
	void Update () {

		//控制水平移动
		if(Input.GetMouseButton(0))                                 //取角色朝向，横向移动
        {
            foreach (Transform child in this.transform)
               {
                if (child.name == "Head")
                {
                    h = child.forward;
                }
               }
            this.transform.position +=new Vector3(h.x * Time.deltaTime*speed ,0,h.z * Time.deltaTime * speed );
        }



		//控制垂直速度大小
		if(speedy <= maxSpeed)
		{
			speedy += Time.deltaTime * g;
		}else{
			speedy += Time.deltaTime * f; 
		}

        //控制竖直方向移动
      
        if(SceneManager.GetActiveScene().name != "test")
        {
            transform.Translate(new Vector3(0, -speedy * Time.deltaTime, 0));
        }
        else if (mbm.enabled == false && SceneManager.GetActiveScene().name == "test")
        {
            transform.Translate(new Vector3(0, -speedy * Time.deltaTime, 0));
        }


        //是否低于传送阵
        if (send != null &&  send.transform.position.y - transform.position.y > 200)
        {
            // game over

            PlayerPrefs.SetString("SaveData", SceneManager.GetActiveScene().name);
            DataController.lastscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("dead");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boost"|| other.tag == "barrer" || other.tag == "destroy" )                 //判断收集品个数
            DataController.collections++;

    }
}
