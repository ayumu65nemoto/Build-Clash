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

    void Start()
    {
        //inSlotFlag = false;
        SlotCount = 0;
    }

    void Update()
    {
        //inSlotFlag = false;
        Debug.Log(SlotCount);
        SlotCount = 0;
    }

    void OnTriggerStay(Collider other)
    {
        //inSlotFlag = true;
            
        //�h���b�O����߂���
        if (CardDrag.DragFlag == false)
        {
            //�z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���
            //CardDrag.DragFlag = true;
            SlotCount = 1;
        }
    }

    void OnTriggerExit()
    {       
        
    }
}
