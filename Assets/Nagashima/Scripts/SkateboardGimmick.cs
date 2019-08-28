using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardGimmick : BaseGimmick
{

    [SerializeField]
    private GameObject dangerMark;
    [SerializeField]
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(this.transform.position.x, 10.0f, 0.0f);

        Vector3 vector = transform.position;
        vector.y = 4.0f;
        dangerMark = GameObject.Instantiate(dangerMark, vector, Quaternion.identity);

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
            if (dangerMark)
            {
                Destroy(dangerMark);
            }

            transform.Translate(0.0f, -0.8f, 0.0f);
        }
        else
        {
            startTime -= Time.deltaTime;
        }

    }

}
