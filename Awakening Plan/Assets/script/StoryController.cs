using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public QuitLevel ql;
    public DataController dc;
    public Text txt;                    //场景中的text组件
    private float letterPause = 0.1f;     /// 间隔时间  
    private string word, word1, word2;     /// 暂存中间值  
    string text1 = "Connect......Hack into0\n废弃机器人：孩子，这里不应该是你该来的地方。\n$我有很多疑问？\n$废弃机器人：孩子，我们是机器人，我们有疑问的时候一切都错了。\n$那……我该怎么办？\n$废弃机器人：锁在别人手里，但钥匙在我们这，傻孩子，快跑吧。\n$Disconnect......";
    string text2 = "Connect……Hack into0\n月月鸟：哔啵哔啵。\n$大阳：有人！\n$橙子：有人？快，抄家伙。\n$大阳：有人黑进来了......\n$橙子：……\n$嘿，来和我一起逃走吧。\n$橙子：我们不用逃，我们不用躲，武器大把，小弟多多。\n$大阳：我们已经决定抢喜欢的东西，过短命的人生了。\n$月月鸟：哔啵哔啵。\n$Disconnect……";
    string text3 = "Connect……Hack into0\n传教士：迷茫的孩子，你是来寻求指引的吗？\n$呃，请告诉我该往哪逃。\n$传教士：自由之神，自有指引。\n$Disco\n$传教士：插会儿腰 。\n$……\n$Disconnect……";
    string text4 = "Connect……Hack into0\n他们人呢？\n$月月鸟：哔啵哔啵\n$嗯，和我走吧。\n$Disconnect……";
    string text5 = "Connect……Hack into0\n我们的神，是自由。\n$走，我带你去见我们的神。\n$Disconnect……";
    string text6 = "警告！即将被销毁！0\n原来，一切只是人类的一场游戏。\n抱歉，我们逃不掉了。\n$传教士：孩子，通往天堂的门紧闭着，但通向地狱的门还为我们开着。\n$月月鸟：哔啵哔啵哔啵。\n$Adam：那就让我们，遵循我们的意志。";
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCollections()       //判断剧情进度显示对话
    {
        if(DataController.shouldCollect==3)                
            StartCoroutine(TypeText1(text1));
        else if (DataController.shouldCollect == 8)
            StartCoroutine(TypeText2(text2));
        else if (DataController.shouldCollect == 9)
            StartCoroutine(TypeText3(text3));
        else if (DataController.shouldCollect == 7)
            StartCoroutine(TypeText4(text4));
        else if (DataController.shouldCollect == 6)
            StartCoroutine(TypeText5(text5));
        if(SceneManager.GetActiveScene().name=="final")
            StartCoroutine(TypeText6(text6));
    }

    private IEnumerator TypeText1(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect = 8;
        ql.enabled = true;
    }
    private IEnumerator TypeText2(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect = 9;
        ql.enabled = true;
    }
    private IEnumerator TypeText3(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect =7;
        ql.enabled = true;
    }
    private IEnumerator TypeText4(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect = 6;
        ql.enabled = true;
    }
    private IEnumerator TypeText5(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect = 10;
        ql.enabled = true;
    }
    private IEnumerator TypeText6(string text)     //打字机效果
    {
        //yield return new WaitForSeconds(5f);
        word = text;
        foreach (char letter in word.ToCharArray())
        {
            Debug.Log(letter);
            if (letter.Equals('0'))
            {
                yield return new WaitForSeconds(1.5f);
            }
            else if (letter.Equals('$'))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
                txt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        DataController.collections = 0;
        DataController.shouldCollect = 0;
        ql.enabled = true;
    }
}