using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class CardSlot3 : MonoBehaviour
{
    public static bool inSlotFlag;

    public int SlotCount;

    public int DeckCount = 0;

    public CardDrag carddrag;
    private GameObject DeckManager;
    private DeckManager deckmanager;



    void Start()
    {
        inSlotFlag = false;

        DeckManager = GameObject.Find("DeckManager");
        deckmanager = DeckManager.GetComponent<DeckManager>();
    }

    void Update()
    {
        inSlotFlag = false;
        Debug.Log(SlotCount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (DeckCount == 1)
        {
            DeckCount++;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (DeckCount == 0)
        {
            inSlotFlag = true;
        }

        if (DeckCount == 1)
        {
            inSlotFlag = false;
        }


        if (DeckCount == 0)
        {
            //�h���b�O����߂���
            if (CardDrag.DragFlag == false)
            {
                //�z�����ށi�ʒu�����킹��j
                other.transform.position = this.transform.position;
                //�z�����ݏI�������t���O���
                CardDrag.DragFlag = true;

                if (DeckCount == 0)
                {
                    deckmanager.DeckArrays[2] = other.gameObject;
                    DeckCount++;
                }
            }
        }
    }

    void OnTriggerExit()
    {
        if (DeckCount == 1)
        {
            DeckCount--;
        }

        if (DeckCount == 2)
        {
            DeckCount--;
        }
    }
}


