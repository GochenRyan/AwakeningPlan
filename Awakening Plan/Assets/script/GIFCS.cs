using UnityEngine;
using System.Collections;

public class GIFCS : MonoBehaviour
{

    // Use this for initialization  
    //public GameObject plane;
    private Texture2D[] anim;
    private int nowFram = 0;
    private int mFrameCount;
    public float fps = 5;
    private float time = 0;
    private int index;
    void Start()
    {
        //在project 下面建立Resources/animation,名字自定义；  
        anim = Resources.LoadAll<Texture2D>("animation");
        //获取图片数量  
        mFrameCount = anim.Length;
        Debug.Log(mFrameCount);

    }


    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.0 / fps)
        {
            nowFram++;
            time = 0;

            index = nowFram % mFrameCount;    //数组的索引，根据时间改变，当前时间乘以fps与总帧数取余，就是播放的当前帧，随着update更新
                                              // anim[index].alphaIsTransparency = true;
            this.GetComponent<Renderer>().material.mainTexture = anim[index];    //渲染这个贴图
        }

    }
}