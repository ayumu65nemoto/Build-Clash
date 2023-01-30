using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCube : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();

    GameObject Listsaver;
    ListSaver ListS;
    Vector3 reset;
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
        Listsaver = GameObject.Find("ListSaver");
        ListS = Listsaver.GetComponent<ListSaver>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(10, 0, 0) * Time.deltaTime / 2;
    }

    void OnTriggerEnter(Collider other)
    {
        //foreach (string CUBE in myList)
        //{
            //Debug.Log(CUBE);
        //}

        if (other.gameObject.layer == 7) //CraftBlock
        {
            ListS.saveList.Add(other.gameObject);
            other.gameObject.SetActive(false);
            reset = Vector3.one;
            other.gameObject.transform.position += reset;
        }

    }

    void ListActive()
    {
        for (int i = 0; i < myList.Count; i++)
        {
            ListS.saveList[i].gameObject.SetActive(true);
        }
    }

    public void OnClickStartButton()
    {
        ListActive();
    }
}
