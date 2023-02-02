using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class CardDrag : MonoBehaviour
{
    //ボックスの中にオブジェクトを吸い込んでいい時はFalse
    public static bool DragFlag;

    //カメラから見たワールド座標
    public Vector3 objPos;

    //カードの初期座標
    public Vector3 StartPos;

    //スロットのスクリプト取得
    public CardSlot cardslot;
    public CardSlot2 cardslot2;
    public CardSlot3 cardslot3;

    public GameObject[] units = new GameObject[3];

    //public GameObject unit;

    //GameObject[] units;

    void Start()
    {
        //初期位置の代入
        StartPos = this.transform.localPosition;

        //units = new GameObject[] { unit };
    }

    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        //ドラッグしてるよフラグ
        DragFlag = true;

        //マウス操作（Z軸以外）
        objPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //ドラッグしてないよフラグ
        DragFlag = false;

        if(CardSlot.inSlotFlag == false && CardSlot2.inSlotFlag == false && CardSlot3.inSlotFlag == false)
        {
            //どのスロットにも触れていなければ初期座標に戻る
            this.transform.localPosition = StartPos;
        }
    }
}
