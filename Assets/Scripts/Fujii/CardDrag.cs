using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class CardDrag : MonoBehaviour
{
    //ボックスの中にオブジェクトを吸い込んでいい時はFalse
    public static bool boxFlag;

    public Vector3 objPos;
    public Vector3 StartPos;

    void Start()
    {
        StartPos = this.transform.localPosition;
    }

    void OnMouseDrag()
    {
        //ドラッグ中は吸い込んではだめ
        boxFlag = true;

        objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //ドラッグ終了、吸い込んでよし
        boxFlag = false;

        if(CardSlot.inSlotFlag == false)
        {
            this.transform.localPosition = StartPos;
        }
    }
}
