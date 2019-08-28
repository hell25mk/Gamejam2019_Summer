using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    PlayerMgr playerMgr;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerMgr = player.GetComponent<PlayerMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMgr.GetIsFall() == false)
        {
            transform.position += new Vector3(0.0f, playerMgr.GetUpSpeed(), 0.0f);
        }
    }
}
