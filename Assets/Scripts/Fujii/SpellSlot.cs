using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class SpellSlot : MonoBehaviour
{
    //�X���b�g�ɃJ�[�h�������Ă��邩�ǂ����̃t���O
    public static bool inSpellSlotFlag;

    //�J�[�h���X���b�g��1����������Ȃ��悤�ɂ��邽�߂̕ϐ�
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
                //�h���b�O����߂���
                if (SpellDrag.DragFlag == false)
                {
                    //�z�����ށi�ʒu�����킹��j
                    other.transform.position = this.transform.position;
                    //�z�����ݏI�������t���O���
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
