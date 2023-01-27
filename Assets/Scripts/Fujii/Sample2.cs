using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sample2 : MonoBehaviour
{

    Rigidbody rd;
    BoxCollider bx;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        bx = this.GetComponent<BoxCollider>();

        //transform.parent = GameObject.Find("PrehabMaster").transform;
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        rd = this.GetComponent<Rigidbody>(); //use guravity �̎擾
        rd.useGravity = true; //�d�̗͂L��

        //bx.isTrigger = false;

        transform.parent = GameObject.Find("ListSaver").transform; //�e����
    }
}
