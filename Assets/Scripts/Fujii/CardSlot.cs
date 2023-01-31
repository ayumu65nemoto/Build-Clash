using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class CardSlot : MonoBehaviour
{
    public static bool inSlotFlag;

    int SlotFlag = 0;

    void Start()
    {
        inSlotFlag = false;
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        inSlotFlag = false;

        //ドラッグしてない時は
        if (CardDrag.boxFlag == false)
        {
            //吸い込む（位置を合わせる）
            //other.transform.position = this.transform.position;
            //吸い込み終わったらフラグ解放

            //CardDrag.boxFlag = true;

            //if(SlotFlag <= 3)
           // {
                SlotFlag++;
                other.transform.position = this.transform.position;
                //inSlotFlag = false;
            //}
        }
    }

    void OnTriggerExit(Collider other)
    {
        inSlotFlag = false;
    }

}
