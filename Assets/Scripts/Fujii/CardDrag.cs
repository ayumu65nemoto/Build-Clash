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

    //�J�������猩�����[���h���W
    public Vector3 objPos;

    //�J�[�h�̏������W
    public Vector3 StartPos;

    //�X���b�g�̃X�N���v�g�擾
    public CardSlot cardslot;
    public CardSlot2 cardslot2;
    public CardSlot3 cardslot3;

    public GameObject[] units = new GameObject[3];

    //public GameObject unit;

    //GameObject[] units;

    void Start()
    {
        //�����ʒu�̑��
        StartPos = this.transform.localPosition;

        //units = new GameObject[] { unit };
    }

    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        //�h���b�O���Ă��t���O
        DragFlag = true;

        //�}�E�X����iZ���ȊO�j
        objPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //�h���b�O���ĂȂ���t���O
        DragFlag = false;

        if(CardSlot.inSlotFlag == false && CardSlot2.inSlotFlag == false && CardSlot3.inSlotFlag == false)
        {
            //�ǂ̃X���b�g�ɂ��G��Ă��Ȃ���Ώ������W�ɖ߂�
            this.transform.localPosition = StartPos;
        }
    }
}
