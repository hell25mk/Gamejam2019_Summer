using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float upSpeed;    //速度(縦)
    private float slideSpeed;  //速度(横)
    Vector2 pos;            //位置座標

    // Start is called before the first frame update
    void Start()
    {
        upSpeed = 0.01f;
        slideSpeed = 0.02f;
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;
    }

    //縦に自動で移動
    public void AutoMove()
    {
        pos.y += upSpeed;
    }
    //右に移動
    public void MoveRight()
    {
        pos.x += slideSpeed;
    }
    //左に移動
    public void MoveLeft()
    {
        pos.x -= slideSpeed;
    }
}
