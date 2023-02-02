using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public static bool inSlot;

    // Start is called before the first frame update
    void Start()
    {
        inSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        inSlot = false;
    }

    void OnTriggerStay(Collider other)
    {
        inSlot = true;

        //�h���b�O���ĂȂ�����
        if (CardDrag.dragFlag == false)
        {
            //�z�����ށi�ʒu�����킹��j
            other.transform.position = this.transform.position;
            //�z�����ݏI�������t���O���
            CardDrag.dragFlag = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        inSlot = false;
    }
}
