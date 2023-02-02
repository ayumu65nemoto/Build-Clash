using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class CardDrag : MonoBehaviour
{
    //�{�b�N�X�̒��ɃI�u�W�F�N�g���z������ł�������False
    public static bool DragFlag;

    public Vector3 objPos;
    public Vector3 StartPos;

    public CardSlot cardslot;

    void Start()
    {
        StartPos = this.transform.localPosition;
    }

    void OnMouseDrag()
    {
        //�h���b�O���͋z������ł͂���
       DragFlag = true;

        objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //�h���b�O�I���A�z������ł悵
        DragFlag = false;

        if(/*CardSlot.inSlotFlag == false*/ cardslot.SlotCount == 0)
        {
            this.transform.localPosition = StartPos;
        }
    }
}
