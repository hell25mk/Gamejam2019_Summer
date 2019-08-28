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
    Gimmick_Bicycle,
    Gimmick_Skateboard,
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

        //テスト　キーボードで生成（ただしマウスカーソルの座標に生成する）
        if (Input.GetKeyDown(KeyCode.W))
        {
            //カメラのz座標位置に生成すると画像が見えなくなるので0に修正する
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_Daruma, mouse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_BalanceBall, mouse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_Bicycle, mouse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0.0f;
            CreateGimmick(eGimmickType.Gimmick_Skateboard, mouse);
        }

    }

    /// <summary>
    /// リストに登録されたギミックを生成する
    /// </summary>
    /// <param name="number">生成するギミックのリスト番号</param>
    /// <param name="vector">生成位置</param>
    public void CreateGimmick(eGimmickType type, Vector3 vector)
    {

        //リストに存在しなかった場合処理を終了する
        if(gimmickList.Count <= (int)type)
        {
            Debug.LogError("リストにデータが存在しません");
            return;
        }

        GameObject.Instantiate(gimmickList[(int)type], vector, Quaternion.identity);

    }

}
