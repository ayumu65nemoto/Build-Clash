using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCube : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();

    //void ListHidden()
    //{
        //for (int i = 0; i < myList.Count; i++)
        //{
            //myList[i].ListCube.SetActive(false);
        //}
    //}

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime / 2;
    }

    void OnTriggerEnter(Collider other)
    {
        //foreach (string CUBE in myList)
        //{
            //Debug.Log(CUBE);
        //}

        if (other.gameObject.tag == "CraftBlock")
        {
            myList.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "CraftBlock2")
        {
            myList.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "CraftBlock3")
        {
            myList.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    void ListActive()
    {
        for (int i = 0; i < myList.Count; i++)
        {
            myList[i].gameObject.SetActive(true);
        }
    }

    public void OnClickStartButton()
    {
        ListActive();
    }
}
