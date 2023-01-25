using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftFrame : MonoBehaviour
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
        craftOK.craftStart = true;
       
    }
    void OnTriggerExit(Collider other)
    {
        //craftOK.craftStart = false;
        craftOK.Death = null;
    }
}
