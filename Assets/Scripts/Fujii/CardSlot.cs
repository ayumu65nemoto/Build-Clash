using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;              // �ǉ�
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class CardSlot : MonoBehaviour
{
    //�X���b�g�ɃJ�[�h�������Ă��邩�ǂ����̃t���O
    public static bool inSlotFlag;

    //�J�[�h���X���b�g��1����������Ȃ��悤�ɂ��邽�߂̕ϐ�
    public int DeckCount = 0;

    public CardDrag carddrag;

    private GameObject DeckManager;
    private DeckManager deckmanager;

    private GameObject GameManager; //
    private GameManager gamemanager; //

    void Start()
    {
        inSlotFlag = false;

        DeckManager = GameObject.Find("DeckManager");
        deckmanager = DeckManager.GetComponent<DeckManager>();

        GameManager = GameObject.Find("GameManager"); //
        gamemanager = GameManager.GetComponent<GameManager>(); //
    }

    void Update()
    {
        inSlotFlag = false;
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
        if(DeckCount == 0)
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
                    deckmanager.DeckArrays[0] = other.gameObject; 
                    DeckCount++;

                    gamemanager.decks[0] = other.gameObject; //
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
