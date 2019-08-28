using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseGimmick : MonoBehaviour
{
    [SerializeField]
    protected int maxActiveTime;      //そのオブジェクトの活動可能時間
    protected int activeTimer;        //現在の活動時間

    // Start is called before the first frame update
    void Start()
    {

        activeTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {

        OnUpdate();

    }

    /// <summary>
    /// 子から呼び出しやすいように必要最低限をまとめた処理
    /// </summary>
    protected void OnUpdate()
    {

        ActiveUpdate();

        Move();

    }

    /// <summary>
    /// 一定時間経過で自身のオブジェクトを削除
    /// </summary>
    public void ActiveUpdate()
    {

        activeTimer++;

        //時間経過で削除
        if (activeTimer > maxActiveTime)
        {
            Destroy(this.gameObject);
            Debug.Log("寿命があぁぁ");
            return;
        }

    }

    /// <summary>
    /// オブジェクトを移動させる
    /// 実装は継承したクラス内で作る
    /// </summary>
    protected virtual void Move()
    {

    }

}
