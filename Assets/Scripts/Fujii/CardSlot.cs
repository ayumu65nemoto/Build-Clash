using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class CardSlot : MonoBehaviour
{
    public static bool inSlotFlag;

    void start()
    {
        inSlotFlag = false;
    }

    void update()
    {
        inSlotFlag = false;
    }

    void OnTriggerStay(Collider other)
    {
        inSlotFlag = true;

        //�h���b�O���ĂȂ�����
        if (CardDrag.boxFlag == false)
        {
            //�z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���
            CardDrag.boxFlag = true;
        }
    }

}
