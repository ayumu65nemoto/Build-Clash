using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCube : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();

    GameObject Listsaver;
    GameManager _GM;

    Vector3 reset;
    //void ListHidden()
    //{
    //for (int i = 0; i < myList.Count; i++)
    //{
    //myList[i].ListCube.SetActive(false);
    //}
    //}
    private int _listCount;
    private PhotonConnecter _photonConnecter;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Listsaver = GameObject.Find("GameManager");
        _GM = Listsaver.GetComponent<GameManager>();
        _photonConnecter = GameObject.Find("PhotonController").GetComponent<PhotonConnecter>();
        _listCount = 0;
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
            _GM.myList.Add(other.gameObject.name);
            _GM.PosList.Add(other.gameObject.transform.position);
            other.gameObject.SetActive(false);
            reset = Vector3.one;
            other.gameObject.transform.position += reset;

            /*if (other.gameObject.CompareTag("CraftBlock"))
            {
            }
            else if (other.gameObject.CompareTag("CraftBlock2"))
            {

            }
            else if (other.gameObject.CompareTag("CraftBlock3"))
            {

            }
            else if (other.gameObject.CompareTag("KING"))
            {

            }*/
            //_GM.myLists[_listCount] = other.gameObject;
            //_listCount += 1;
            
            if (_photonConnecter.playerId == 1)
            {
                _GM.myList.Add(other.gameObject.name);
                _GM.PosList.Add(other.gameObject.transform.position);
                other.gameObject.SetActive(false);
                reset = Vector3.one;
                other.gameObject.transform.position += reset;
            }
            if (_photonConnecter.playerId == 2)
            {
                _GM.otherList.Add(other.gameObject.name);
                _GM.PosList2.Add(other.gameObject.transform.position);
                other.gameObject.SetActive(false);
                reset = Vector3.one;
                other.gameObject.transform.position += reset;
            }
        }

    }

    void ListActive()
    {
        for (int i = 0; i < myList.Count; i++)
        {
            //ListS.saveList[i].gameObject.SetActive(true);
        }
    }

    public void OnClickStartButton()
    {
        ListActive();
    }
}
