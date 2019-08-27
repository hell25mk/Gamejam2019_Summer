using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBallGimmick : BaseGimmick
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        base.OnUpdate();

        Move();

    }

    public void Move()
    {

        transform.Translate(-0.05f, 0.0f, 0.0f);

    }

}
