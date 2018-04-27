using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouse : MonoBehaviour {
    public float  speed = 10f;
    int button =1;
    public ParticleSystem ps;
    public CanvasGroup cg;
    public Move move;
    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, -3f, 0);
        ps.enableEmission = false;
        move.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        cg.alpha -= 0.05f * Time.deltaTime;
        if(cg.alpha<0.3f)
            button = 0;

        if (button == 0)
        {
            //speed += 0.02f;
            this.gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));                 //第一关移动角色
            if (this.gameObject.transform.localPosition.x < -5)
            {
                this.gameObject.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
				Move.jduge = true;
                ps.enableEmission = true;
                move.enabled = true;
                this.enabled = false;
            }
        }
    }
}
