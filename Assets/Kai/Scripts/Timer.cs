using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float totalTime;//トータル制限時間
    public int minute;//制限時間（分）
    public float seconds;//制限時間（秒）
    float oldSeconds;//前回Update時の秒数

    Text timerText;

    void Start()
    {
        totalTime = minute * 60 + seconds;
        seconds++;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //制限時間が0秒以下なら何もしない
        if (totalTime > 1)
        {
            //一旦トータルの制限時間を計測；
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;

            //再設定
            minute = (int)totalTime / 60;
            seconds = totalTime - minute * 60;

            //タイマー表示用UIテキストに時間を表示する
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;

            //制限時間以下になったらタイムアップと表示する
            if (totalTime < 1)
            {
                //テキストを表示
                GameObject GoalText;
                GoalText = GameObject.Find("Text");
                Text text = GoalText.GetComponent<Text>();
                text.text = "タイムアップ！";
                //シーン移動
                StartCoroutine("ChangeScene");
            }
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
    }
}
