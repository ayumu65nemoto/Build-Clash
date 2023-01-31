using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject script;
    crafter craftOK;

    void Awake()
    {
        script = GameObject.Find("CraftManager");
        craftOK = script.GetComponent<crafter>();
    }
    void OnTriggerStay(Collider other)
    {
        craftOK.DeleteOK = true;
        if (other.gameObject.tag == "CraftBlock")
        {
            craftOK.Death = other.gameObject;
            craftOK.Once = other.transform.position;
            craftOK.ReturnCost = 1;
            craftOK.craftStart = false;
        }
        if (other.gameObject.tag == "CraftBlock2")
        {
            craftOK.Death = other.gameObject;
            craftOK.Once = other.transform.position;
            craftOK.ReturnCost = 3;
            craftOK.craftStart = false;
        }
        if (other.gameObject.tag == "CraftBlock3")
        {
            craftOK.Death = other.gameObject;
            craftOK.Once = other.transform.position;
            craftOK.ReturnCost = 5;
            craftOK.craftStart = false;
        }
        if (other.gameObject.tag == "KING")
        {
            craftOK.Death = other.gameObject;
            craftOK.Once = other.transform.position;
            craftOK.ReturnCost = 0;
            craftOK.craftStart = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        craftOK.DeleteOK = false;
        craftOK.Death = null;
        craftOK.craftStart = true;
    }
}
