using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    float fallCnt;          //転ぶまでのカウント
    [SerializeField]
    const float fallCntLimit = 0.8f;     //転ぶまでカウントの上限値
    float fallTimeCnt;         //転んでいる時間のカウント
    [SerializeField]
    const float fallTimeCntLimit = 1.0f;    //転んでいるカウントの上限値

    private bool isFall;    //転倒フラグ true:転んでいる false:起きている
    public int falledCnt;     //転んだ回数

    [SerializeField]
    private float upSpeed;    //速度(縦)
    [SerializeField]
    private float slideSpeed;  //速度(横)
    Vector2 pos;            //位置座標

    SpriteRenderer MainSpriteRenderer;
    public Sprite fallSprite;
    public Sprite run;

    // Start is called before the first frame update
    void Start()
    {
        fallCnt = 0.0f;
        fallTimeCnt = 0.0f;
        isFall = false;

        upSpeed = 0.01f;
        slideSpeed = 0.02f;
        pos = transform.position;

        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 状態の更新
        StateMgr();

        //座標の更新
        transform.position = pos;

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
                Fall();
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
                GetUp();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fall();
    }

    //転ぶ
    void Fall()
    {
        isFall = true;
        MainSpriteRenderer.sprite = fallSprite;
        falledCnt++;
        fallCnt = 0.0f;
    }

    //起き上がる
    void GetUp()
    {
        isFall = false;
        MainSpriteRenderer.sprite = run;
        fallTimeCnt = 0.0f;
    }

    //上　自動移動
    void UpMove()
    {
        pos.y += upSpeed;
    }
    //左
    void MoveLeft()
    {
        pos.x -= slideSpeed;
    }
    //右
    void MoveRight()
    {
        pos.x += slideSpeed;
    }



}
