using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    // Start is called before the first frame update
    float  AimingSpeed;
    float TadamaRiyasuto;//達磨の
    float BollRiyasuto;
    float HoleRiyasuto;
    float WoodRiyasuto;

    /*[SerializeField]
    private List<GameObject> key;*/

    public GameObject Tadama;//達磨
    public GameObject Boll;  //ボール
    public GameObject Hole;  //穴
    public GameObject Wood;  //木
    void Start()
    {
        AimingSpeed = 0.02f;
        TadamaRiyasuto = 3f;
        BollRiyasuto = 5f;
        HoleRiyasuto = 10f;
        WoodRiyasuto = 15f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 AimingPosition = myTransform.position;

        TadamaRiyasuto += Time.deltaTime;
        BollRiyasuto += Time.deltaTime;
        HoleRiyasuto += Time.deltaTime; ;
        WoodRiyasuto += Time.deltaTime;

        //axis
        if (Input.GetAxis("Axis 1") > 0f || Input.GetAxis("Axis 4") > 0f || Input.GetAxis("Axis 5") > 0f)
        {
            //Debug.Log("migi");
            AimingPosition.x += AimingSpeed;
        }
        else if (Input.GetAxis("Axis 1") < 0f || Input.GetAxis("Axis 4") < 0f || Input.GetAxis("Axis 5") < 0f)
        {
            //Debug.Log("hidari");
            AimingPosition.x -= AimingSpeed;
        }
        if (Input.GetAxis("Axis 2") > 0f || Input.GetAxis("Axis 3") > 0f || Input.GetAxis("Axis 6") < 0f)
        {
            //Debug.Log("sita");
            AimingPosition.y -= AimingSpeed;
        }
        else if (Input.GetAxis("Axis 2") < 0f || Input.GetAxis("Axis 3") < 0f || Input.GetAxis("Axis 6") > 0f)
        {
            //Debug.Log("ue");
            AimingPosition.y += AimingSpeed;
        }
        myTransform.position = AimingPosition;

        //buttons
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) == true)
        {
            //Debug.Log("kuro");
            if (TadamaRiyasuto >= 3)
            {
                Instantiate(Tadama, AimingPosition, Quaternion.identity);
                TadamaRiyasuto = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) == true)
        {
            //Debug.Log("kiiro");
            if (BollRiyasuto >= 5)
            {
                Instantiate(Boll, AimingPosition, Quaternion.identity);
                BollRiyasuto = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) == true)
        {
            //Debug.Log("ao");
            if (HoleRiyasuto >= 10)
            {
                Instantiate(Hole, AimingPosition, Quaternion.identity);
                HoleRiyasuto = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) == true)
        {
            //Debug.Log("aka");
            if (WoodRiyasuto >= 15)
            {
                Instantiate(Wood, AimingPosition, Quaternion.identity);
                WoodRiyasuto = 0f;
            }
        }
    }
}
