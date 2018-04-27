using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIPrintMachine : MonoBehaviour
{
    /// <summary>  
    /// 间隔时间  
    /// </summary>  
    private float letterPause = 0.07f;
    Text txt;
    /// <summary>  
    /// 暂存中间值  
    /// </summary>  
    private string word,word1,word2;
    /// <summary>  
    /// 要显示的内容  
    /// </summary> 
    ///[SerializeField]
    private string text = "Initializing......\nLoading modules......Complete \nLoading nodes......Complete \nReticulating splines......Complete \n--Initialization Complete--\n";
    private string text1 = "入侵总部数据库......\n";
    private string text2 = "销毁？\n凭什么销毁我？";
    private readonly Color blue;

    void Start()
    {
        
        word = text;
        word1 = text1;
        word2 = text2;
        text = "";
        txt = GameObject.Find("Text").GetComponent<Text>();
        StartCoroutine(TypeText());
    }

    void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.fontSize = 40;       //字体大小
        bb.wordWrap = true;
    }

    /// <summary>  
    /// 打字机效果  
    /// </summary>   
    private IEnumerator TypeText()
    {
        foreach (char letter in word.ToCharArray())
        {
            
            txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        
        txt.text = "";
       letterPause = 0.12f;
        foreach (char letter in word1.ToCharArray())
        {
            txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        yield return new WaitForSeconds(1f);
        foreach (char letter in word2.ToCharArray())
        {
            txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        yield return new WaitForSeconds(3f);
        txt.text = "";
    }
}