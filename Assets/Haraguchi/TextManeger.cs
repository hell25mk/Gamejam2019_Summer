using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManeger : MonoBehaviour
{
    [SerializeField]
    private List<string> Text;
    public GameObject MainPlayerIntimacyMeter = null;//メインプレイヤー結果
    public GameObject MainPlayerComment = null;//インプレイヤーコメント
    public GameObject IntimacyMeter = null;//邪魔者結果
    public GameObject Comment = null;//邪魔者コメント

    private int rollOverCnt;//こけた回数
    private float result;
    private bool firstFlg = false;//一回だけ行う
    private bool timeFlg = false;//時間で動く
    private float maxPercent = 100f;//100%から引き算をする

    // Start is called before the first frame update
    void Start()
    {
        rollOverCnt= PlayerMgr.falledCnt;
        //rollOverCnt = 13;//仮に  回こけた
        result = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Text MainPlayerIntimacyMeterText = MainPlayerIntimacyMeter.GetComponent<Text>();
        Text MainPlayerCommentText = MainPlayerComment.GetComponent<Text>();
        Text IntimacyMeterText = IntimacyMeter.GetComponent<Text>();
        Text CommentText = Comment.GetComponent<Text>();

        if (firstFlg == false)
        {
            for (int i = 0; i < rollOverCnt; i++)
            {
                result = result * 1.6f;
            }
            maxPercent = maxPercent - result;
           // Debug.Log(result);
           // Debug.Log(maxPercent);
            MainPlayerIntimacyMeterText.text = maxPercent.ToString("f1") + "%です";
            IntimacyMeterText.text =  result.ToString("f1") + "%です";
            firstFlg = true;
        }
        MainPlayerResult();
        DisturberResult();

        if (Input.GetKey(KeyCode.Return))
        {
           Quit();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");//タイトル名
        }

    }
    void MainPlayerResult()
    {
        Text MainPlayerIntimacyMeterText = MainPlayerIntimacyMeter.GetComponent<Text>();
        Text MainPlayerCommentText = MainPlayerComment.GetComponent<Text>();

        if (maxPercent < 0)//マイナス桁
        {
            //CommentText.text = List < 0 >//"わかれたほうがいいね";
            MainPlayerCommentText.text ="わかれたほうがいいね";
        }
        if (maxPercent >= 0 && maxPercent < 30)//0～30%
        {
            MainPlayerCommentText.text = "まずまずだね、片思いかな";
        }
        if (maxPercent >= 30 && maxPercent < 60)//30～60%
        {
            MainPlayerCommentText.text = "いいね、新婚さん？？";
        }
        if (maxPercent >= 60 && maxPercent < 90)//60～90%
        {
            MainPlayerCommentText.text = "すごい！熟年夫婦でしょ";
        }
        if (maxPercent >= 90)//90～100%
        {
            MainPlayerCommentText.text = "もはやただのバカップル";
        }

    }
    void DisturberResult()
    {
        Text IntimacyMeterText = IntimacyMeter.GetComponent<Text>();
        Text CommentText = Comment.GetComponent<Text>();

        if (result >=0 && result < 33)//0～33%
        {
            CommentText.text = "なにかしてたの？？";
        }
        if(result >=33 && result < 66)//33～66%
        {
            CommentText.text = "爆発させたね";
        }
        if(result >=66 && result < 99)//66～99%
        {
            CommentText.text = "ラブクラッシャーw";
        }
        if(result >= 99)//99～%
        {
            CommentText.text = "あなたはきっと怨結びの神様だよ";
        }
    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }

}
