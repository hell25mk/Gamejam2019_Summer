using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックの種類の列挙
/// </summary>
public enum eGimmickType : int
{
    Gimmick_Daruma = 0,
    Gimmick_BalanceBall,
}

public class GimmickManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> gimmickList;

    public void Start()
    {

        if (gimmickList == null)
        {
            gimmickList = new List<GameObject>();
        }

    }

    public void Update()
    {

        //テスト　マウスで生成できるようにしている
        if (Input.GetMouseButtonDown(0))
        {
            //カメラのz座標位置に生成すると画像が見えなくなるので0に修正する
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_Daruma, mouse);
        }

        if (Input.GetMouseButtonDown(1))
        {
            //カメラのz座標位置に生成すると画像が見えなくなるので0に修正する
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_BalanceBall, mouse);
        }

    }

    /// <summary>
    /// リストに登録されたギミックを生成する
    /// </summary>
    /// <param name="number">生成するギミックのリスト番号</param>
    /// <param name="vector">生成位置</param>
    public void CreateGimmick(eGimmickType type, Vector3 vector)
    {

        GameObject.Instantiate(gimmickList[(int)type], vector, Quaternion.identity);

    }

}
