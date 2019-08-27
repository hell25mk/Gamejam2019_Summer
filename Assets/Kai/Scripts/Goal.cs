using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //テキストを表示
            GameObject GoalText;
            GoalText = GameObject.Find("Text");
            Text text = GoalText.GetComponent<Text>();
            text.text = "ゴール！";
            //タイマーを止める
            GameObject Timer = GameObject.Find("Timer");
            Timer script = Timer.GetComponent<Timer>();
            script.enabled = false;
            //シーン移動
            StartCoroutine("ChangeScene");
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        
    }
}
