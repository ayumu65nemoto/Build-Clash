using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleButton : MonoBehaviour
{

    public GameObject tower;
    //public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = (GameObject)Resources.Load("PrehabMaster");

        //Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);

        DontDestroyOnLoad(this.gameObject);
    }

    public void OnClickStartButton()
    {
        //tower.SetActive(false);

        //tower.transform.position += new Vector3(0, 1.0f, 0); //è„è∏â^ìÆ

        //GameObject obj = (GameObject)Resources.Load("PrehabMaster");
        //Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
