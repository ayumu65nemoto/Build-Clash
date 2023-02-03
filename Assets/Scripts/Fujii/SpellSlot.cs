using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // 追加
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class SpellSlot : MonoBehaviour
{
    //スロットにカードが入っているかどうかのフラグ
    public static bool inSpellSlotFlag;

    //カードがスロットに1枚しか入らないようにするための変数
    public int DeckCount = 0;

    public SpellDrag spelldrag;

    private GameObject DeckManager;
    private DeckManager deckmanager;

    private GameObject GameManager; //
    private GameManager gamemanager; //



    void Start()
    {
        inSpellSlotFlag = false;

        DeckManager = GameObject.Find("DeckManager");
        deckmanager = DeckManager.GetComponent<DeckManager>();

        GameManager = GameObject.Find("GameManager"); //
        gamemanager = GameManager.GetComponent<GameManager>(); //
    }

    void Update()
    {
        inSpellSlotFlag = false;

        Debug.Log(DeckCount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spell"))
        {
            if (DeckCount == 1)
            {
                DeckCount++;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Spell"))
        {
            if (DeckCount == 0)
            {
                inSpellSlotFlag = true;
            }

            if (DeckCount == 1)
            {
                inSpellSlotFlag = false;
            }


            if (DeckCount == 0)
            {
                //ドラッグをやめたら
                if (SpellDrag.DragFlag == false)
                {
                    //吸い込む（位置を合わせる）
                    other.transform.position = this.transform.position;
                    //吸い込み終わったらフラグ解放
                    SpellDrag.DragFlag = true;

                    DeckCount++;

                    if (DeckCount == 0)
                    {
                        deckmanager.DeckArrays[3] = other.gameObject;
                        //DeckCount++;

                        gamemanager.decks[3] = other.gameObject.GetComponent<CardDrag>().units[0]; //
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spell"))
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
}
