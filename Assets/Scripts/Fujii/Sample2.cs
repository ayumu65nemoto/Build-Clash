using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sample2 : MonoBehaviour
{
    Vector3 force = new Vector3(0.0f, -5.0f, 0.0f);
    Rigidbody rd;
    BoxCollider bx;
    Vector3 reset;
    Vector3 stop;
    Vector3 Me;
    bool qq=false;
    bool moveOFF = false;
    GameObject script;
    crafter craftOK;
    

    void Awake()
    {
        script = GameObject.Find("CraftManager");
        craftOK = script.GetComponent<crafter>();
        reset = craftOK.F_Pos;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        rd = GetComponent<Rigidbody>();
        rd.sleepThreshold = 1f;
            // 力を設定
        rd.AddForce(force);
        bx = this.GetComponent<BoxCollider>();

        //transform.parent = GameObject.Find("PrehabMaster").transform;
    }
    void Update()
    {
        if (moveOFF == false)
        {
            rd.AddForce(force);
        }
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {


        if (nextScene.name == "PlayScene")
        {
            //use guravity の取得
            //rd.useGravity = true; //重力の有無
            rd.constraints = RigidbodyConstraints.None;
        }
        else
        {

            Me = transform.position;
            Me.x -= reset.x;
            Me.z -= reset.z;
            transform.position = Me;
            rd.constraints = RigidbodyConstraints.FreezeAll;
        }


        //bx.isTrigger = false;
        if (qq == false)
        {
            //reset = this.gameObject.transform.position;
            
            //this.gameObject.transform.position = reset;
            transform.parent = GameObject.Find("ListSaver").transform; //親検索
            qq = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {

        }
        else
        {
            this.gameObject.transform.position = stop;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        stop = this.gameObject.transform.position;
    }
    void OnTriggerExit(Collider other)
    {
        moveOFF = false;
    }
}
