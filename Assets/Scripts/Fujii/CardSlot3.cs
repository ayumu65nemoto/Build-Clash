using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

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
            //ドラッグをやめたら
            if (CardDrag.DragFlag == false)
            {
                //吸い込む（位置を合わせる）
                other.transform.position = this.transform.position;
                //吸い込み終わったらフラグ解放
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


