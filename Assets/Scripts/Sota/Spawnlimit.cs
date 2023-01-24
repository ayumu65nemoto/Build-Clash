using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnlimit : MonoBehaviour
{
    public bool Breaking = false;
    GameObject Trash;
    GameObject script;
    crafter craftOK;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        Trash = null;
        script = GameObject.Find("CraftManager");
        craftOK = script.GetComponent<crafter>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CraftBlock")
        {

            craftOK.craftStart2 = false;
            Trash = other.gameObject;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        craftOK.craftStart2 = true;
    }
    public void Deleted()
    {
        Destroy(Trash);
        Trash = null;
    }
}
