using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    GameObject sceneManager;
    GameObject Text;
    GameObject Shadow;

    Text text;
    Text shadow;

    int mode;

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        Text = GameObject.Find("ComandText");
        Shadow = GameObject.Find("ComandShadowText");
        
        text = Text.GetComponent<Text>();
        shadow = Shadow.GetComponent<Text>();

        mode = 1;
    }

    void Update()
    {
        //カーソル移動
        if (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            mode *= -1;
            if (mode == 1)
            {
                text.text = ("➡ はしる\n　 やめる");
                shadow.text = ("➡ はしる\n　 やめる");
            }
            else
            {
                text.text = ("　 はしる\n➡ やめる");
                shadow.text = ("　 はしる\n➡ やめる");
            }
        }
        //決定
        if (Input.GetKeyDown("space"))
        {
            SceneMoveManager script = sceneManager.GetComponent<SceneMoveManager>();

            if (mode == 1)
            {
                script.LoadScene();
            }
            else
            {
                script.ToGameEnd();
            }
        }
    }
}
