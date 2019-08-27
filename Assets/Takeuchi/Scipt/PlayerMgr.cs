using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    public GameObject man;
    public GameObject woman;
    float fallCnt;          //転ぶまでのカウント
    const float fallCntLimit = 0.5f;     //転ぶまでカウントの上限値
    float fallTimeCnt;         //転んでいる時間のカウント
    const float fallTimeCntLimit = 1.0f;    //転んでいるカウントの上限値

    private bool isFall;    //転倒フラグ true:転んでいる false:起きている

    // Start is called before the first frame update
    void Start()
    {
        man = GameObject.Find("Man");
        woman = GameObject.Find("Woman");

        fallCnt = 0.0f;
        fallTimeCnt = 0.0f;
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 状態の更新
        StateMgr();

        // 転んでいなければ自動で移動
        if (isFall == false)
        {
            UpMove();

            // A + ←　
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();     //二人とも左に移動
            }
            // W + →
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();    //二人とも右に移動
            }
        }
    }

    //状態管理
    void StateMgr()
    {
        // 男：右　女：左  || 男：左　女：右
        // 互いに違う動きをしたら
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftArrow) ||
           Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.RightArrow))
        {
            //違う動きをしている時間をカウント
            fallCnt += Time.deltaTime;

            //カウントが一定の値を超えたら転ぶ
            if (fallCnt >= fallCntLimit)
            {
                isFall = true;
                fallCnt = 0.0f;
            }
        }

        //転んでいる時間の処理
        if(isFall == true)
        {
            //転んでいる時間のカウント
            fallTimeCnt += Time.deltaTime;

            //カウントが一定の値を超えたら起き上がる
            if(fallTimeCnt >= fallTimeCntLimit)
            {
                isFall = false;
                fallTimeCnt = 0.0f;
            }
        }
    }

    //上　自動移動
    void UpMove()
    {
        woman.GetComponent<Player>().AutoMove();
        man.GetComponent<Player>().AutoMove();
    }
    //左
    void MoveLeft()
    {
        woman.GetComponent<Player>().MoveLeft();
        man.GetComponent<Player>().MoveLeft();
    }
    //右
    void MoveRight()
    {
        woman.GetComponent<Player>().MoveRight();
        man.GetComponent<Player>().MoveRight();
    }


}
