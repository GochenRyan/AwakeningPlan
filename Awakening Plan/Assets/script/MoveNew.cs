using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNew : MonoBehaviour {
    public float speed = 150f;

	public float maxSpeed = 180f;
    Vector3 h = new Vector3();
    public DataController dc;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {                                 //取角色朝向，横向移动
            foreach (Transform child in this.transform)
            {
                if (child.name

 == "Head")
                {
                    h = child.forward;
                }
            }
            this.transform.position += new Vector3(h.x * Time.deltaTime * speed, 0, h.z * Time.deltaTime * speed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collections")
            DataController.collections++;

    }
    void OnCollisionEnter (Collision other)
    {
       // Debug.Log("2" + other.gameObject.name);
    }
}
