using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{

    //�{�b�N�X�̒��ɃI�u�W�F�N�g���z������ł�������False
    public static bool dragFlag;

    public Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        //�h���b�O���͋z������ł͂���
        dragFlag = true;
        //�ȉ�3�s�̓h���b�O�������ɃI�u�W�F�N�g�𓮂����R�[�h
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //�h���b�O�I���A�z������ł悵
        dragFlag = false;

        if (CardSlot.inSlot == false)
        {
            this.transform.position = StartPos;
        }
    }
}

