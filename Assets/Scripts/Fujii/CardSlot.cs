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

        //ドラッグしてない時は
        if (CardDrag.dragFlag == false)
        {
            //吸い込む（位置を合わせる）
            other.transform.position = this.transform.position;
            //吸い込み終わったらフラグ解放
            CardDrag.dragFlag = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        inSlot = false;
    }
}
