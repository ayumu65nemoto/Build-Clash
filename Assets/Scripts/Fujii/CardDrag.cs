using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{

    //ボックスの中にオブジェクトを吸い込んでいい時はFalse
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
        //ドラッグ中は吸い込んではだめ
        dragFlag = true;
        //以下3行はドラッグした時にオブジェクトを動かすコード
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseUp()
    {
        //ドラッグ終了、吸い込んでよし
        dragFlag = false;

        if (CardSlot.inSlot == false)
        {
            this.transform.position = StartPos;
        }
    }
}

