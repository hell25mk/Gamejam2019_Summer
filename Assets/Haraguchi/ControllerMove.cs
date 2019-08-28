using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    // Start is called before the first frame update
    float  AimingSpeed;

    [SerializeField]
    private List<GameObject> gimmikcList = null;
    [SerializeField]
    private List<float> maxRiyasutoTime = null;

    private List<float> gimmickRiyasuto;

    /*float TadamaRiyasuto;//達磨の
    float BollRiyasuto;
    float HoleRiyasuto;
    float WoodRiyasuto;*/

    /*public GameObject Tadama;//達磨
    public GameObject Boll;  //ボール
    public GameObject Hole;  //穴
    public GameObject Wood;  //木*/

    void Start()
    {
        AimingSpeed = 0.05f;
        gimmickRiyasuto = new List<float>
        {
            maxRiyasutoTime[(int)eGimmickType.Gimmick_Daruma],
            maxRiyasutoTime[(int)eGimmickType.Gimmick_BalanceBall],
            maxRiyasutoTime[(int)eGimmickType.Gimmick_Bicycle],
            maxRiyasutoTime[(int)eGimmickType.Gimmick_Skateboard],
        };
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 AimingPosition = myTransform.position;

        for (int i = 0; i < gimmickRiyasuto.Count; i++)
        {
            gimmickRiyasuto[i] += Time.deltaTime;
        }

        /*TadamaRiyasuto += Time.deltaTime;
        BollRiyasuto += Time.deltaTime;
        HoleRiyasuto += Time.deltaTime; ;
        WoodRiyasuto += Time.deltaTime;*/

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
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("kuro");
            if (gimmickRiyasuto[(int)eGimmickType.Gimmick_Daruma] >= maxRiyasutoTime[(int)eGimmickType.Gimmick_Daruma])
            {
                Instantiate(gimmikcList[(int)eGimmickType.Gimmick_Daruma], AimingPosition, Quaternion.identity);
                gimmickRiyasuto[(int)eGimmickType.Gimmick_Daruma] = 0f;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("kiiro");
            if (gimmickRiyasuto[(int)eGimmickType.Gimmick_BalanceBall] >= maxRiyasutoTime[(int)eGimmickType.Gimmick_BalanceBall])
            {
                Instantiate(gimmikcList[(int)eGimmickType.Gimmick_BalanceBall], AimingPosition, Quaternion.identity);
                gimmickRiyasuto[(int)eGimmickType.Gimmick_BalanceBall] = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("ao");
            if (gimmickRiyasuto[(int)eGimmickType.Gimmick_Bicycle] >= maxRiyasutoTime[(int)eGimmickType.Gimmick_Bicycle])
            {
                Instantiate(gimmikcList[(int)eGimmickType.Gimmick_Bicycle], AimingPosition, Quaternion.identity);
                gimmickRiyasuto[(int)eGimmickType.Gimmick_Bicycle] = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("aka");
            if (gimmickRiyasuto[(int)eGimmickType.Gimmick_Skateboard] >= maxRiyasutoTime[(int)eGimmickType.Gimmick_Skateboard])
            {
                Instantiate(gimmikcList[(int)eGimmickType.Gimmick_Skateboard], AimingPosition, Quaternion.identity);
                gimmickRiyasuto[(int)eGimmickType.Gimmick_Skateboard] = 0f;
            }
        }
    }
}
