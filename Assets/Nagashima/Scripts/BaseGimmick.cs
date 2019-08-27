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

    public virtual void OnUpdate()
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

}
