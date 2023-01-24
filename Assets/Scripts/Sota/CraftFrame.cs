using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftFrame : MonoBehaviour
{
    crafter script;
    void Start()
    {
        script = GameObject.Find("CraftManager").GetComponent<crafter>();
    }
   void OnTriggerStay(Collider other)
    {
        
            script.craftStart = true;
        
    }
    void OnTriggerExit(Collider other)
    {
        script.craftStart = false;
    }


}
