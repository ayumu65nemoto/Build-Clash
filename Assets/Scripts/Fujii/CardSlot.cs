using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class CardSlot : MonoBehaviour
{
    public static bool inSlotFlag;

    public int SlotCount;

    public CardDrag carddrag;
    public CardDrag1 carddrag1;

    void Start()
    {
        inSlotFlag = false;
        SlotCount = 0;
    }

    void Update()
    {
        inSlotFlag = false;
        Debug.Log(SlotCount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (SlotCount == 0)
        {
            SlotCount++;
        }

        if (SlotCount == 3)
        {
            SlotCount -= 3;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (SlotCount == 1)
        {
            inSlotFlag = true;
        }
                   
        //ドラッグをやめたら
        if (CardDrag.DragFlag == false)
        {
            //吸い込む（位置を合わせる）
            other.transform.position = this.transform.position;
            //吸い込み終わったらフラグ解放
            CardDrag.DragFlag = true;

            SlotCount = 3;
        }

        //ドラッグをやめたら
        if (CardDrag1.DragFlag1 == false)
        {
            //吸い込む（位置を合わせる）
            other.transform.position = this.transform.position;
            //吸い込み終わったらフラグ解放
            CardDrag1.DragFlag1 = true;

            SlotCount = 3;
        }
    }

    void OnTriggerExit()
    {
        if(SlotCount == 1)
        {
            SlotCount--;
        }

        if (SlotCount == 3)
        {
            SlotCount -= 3;
        }
    }
}
