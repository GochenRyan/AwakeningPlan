using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {

	public GameObject[] obstacle;

	// 已经生成的障碍物
	private List<GameObject> genedObs = new List<GameObject>(10) ;

	// 生成障碍物 距离人的距离
	private float obsDistance = 2000f; 

	// 障碍物区间
	private float obsInterval = 2000f;

	// 删除障碍物距离人头顶的距离
	private float desObsDis = 500f;

	// 障碍生成的半径
	private int obsR = 340;

	// 障碍物熟练底限
	public int lLimit = 3;

	// 上限
	public int hLimit = 10;

	//上次生成障碍物的顶坐标
	private float lastTop;

	//是否生成了障碍物
	private bool isObs = false;

	private float bongR = 6000f;
	//爆炸
	public void bong(){
		for (int i = 0; i < genedObs.Count; i++) {
			if (System.Math.Abs(genedObs[i].transform.position.y - transform.position.y)   < bongR) {
				GameObject go = genedObs [i];
				genedObs.Remove (genedObs[i]);
				Destroy (go);
			}

		}
	}


	private void destroyObs(){
		for (int i = 0; i < genedObs.Count; i++) {
			if (genedObs[i].transform.position.y - transform.position.y > desObsDis) {
				GameObject go = genedObs [i];
				genedObs.Remove (genedObs[i]);
				Destroy (go);
			}
		
		}
	}

	private void genObs(){

		//随机种子
		System.Random rd = new System.Random ();
		System.Random rd2 = new System.Random ();
		System.Random rd3 = new System.Random ();
		System.Random rd4 = new System.Random ();

		//障碍物个数
		int obsNum = rd.Next (lLimit, hLimit);


		int obsSize = obstacle.Length;

		lastTop = transform.position.y - obsDistance - obsInterval;

		//生成障碍物
		for(int i=0;i<obsNum;i++){

			//生成障碍物的索引
			int k = rd.Next(0,obsSize - 1);
			Vector3 v3 = new Vector3 ();

			//取随机y
			int yMin = (int)(transform.position.y - obsDistance - obsInterval);
			int yMax = (int)(transform.position.y - obsDistance);
			int y = rd.Next(yMin,yMax);
			//Debug.Log (y);

			//取随机x和z
			int x = rd.Next(-obsR,obsR);
			int z = rd2.Next(-obsR,obsR);

			v3.Set (x,y,z);

			Quaternion r3;

			//随机生成旋转度
			// 环不设置旋转度
			if (obstacle [k].tag == "obs") {
			 r3 = new Quaternion (rd.Next (0, 360), rd2.Next (0, 360), rd3.Next (0, 360), rd4.Next (0, 360));
			} else {
				r3 = obstacle [k].transform.rotation;
			}

			//障碍物
			GameObject obs = Instantiate (obstacle[k], v3, r3);

			//障碍物大小
			//obs.transform.localScale = new Vector3 (rd.Next(25,50),rd2.Next(25,50),rd3.Next(25,50));
			genedObs.Add (obs);

		}
	
	}


	// Use this for initialization
	void Start () {
		//墙高 - 生成距 - 生成区间
		lastTop =(float) (6000 * 1.5) - obsDistance - obsInterval; 
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		//Debug.Log (transform.position.y);

		//如果当前位置低于上次生成的y则生成障碍物
		if (transform.position.y - lastTop <=  obsDistance) {

			//生成障碍物
			genObs ();
		}
		destroyObs ();

	}

}
