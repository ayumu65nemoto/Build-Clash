using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

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

        //�h���b�O���ĂȂ�����
        if (CardDrag.boxFlag == false)
        {
            //�z�����ށi�ʒu�����킹��j
            //other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���

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
