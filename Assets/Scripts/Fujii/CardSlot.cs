using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

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
                   
        //�h���b�O����߂���
        if (CardDrag.DragFlag == false)
        {
            //�z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���
            CardDrag.DragFlag = true;

            SlotCount = 3;
        }

        //�h���b�O����߂���
        if (CardDrag1.DragFlag1 == false)
        {
            //�z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���
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
