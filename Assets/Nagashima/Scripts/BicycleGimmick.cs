using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleGimmick : BaseGimmick
{

    [SerializeField]
    float startTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        base.OnUpdate();

    }

    /// <summary>
    /// 一定時間停止し、その後発射する
    /// </summary>
    protected override void Move()
    {

        if (startTime <= 0.0f)
        {
            transform.Translate(0.1f, 0.05f, 0.0f);
        }
        else
        {
            startTime -= Time.deltaTime;
        }

    }

}
