using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class crafter : MonoBehaviour
{
    //AR
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    ARPlaneManager _arPlaneManager;
    Camera arCam;

    //オブジェクト
    [SerializeField]
    GameObject spawnablePrefab;
    [SerializeField]
    GameObject Frame;
    [SerializeField]
    GameObject block1;
    [SerializeField]
    GameObject block2;
    [SerializeField]
    GameObject block3;
    [SerializeField]
    GameObject King;
    [SerializeField]
    GameObject DeleteTool;
    [SerializeField]
    TextMeshProUGUI Cost;

    //クラフトメイン
    int Blocktype = 1;
    public bool king = false;
    int CraftCost;
    public int ReturnCost;
    float c_position = 0.1f;
    Vector3 Main;
   // Vector3 poss;
    public Vector3 CraftMain;
    public Vector3 Once;
    public Vector3 F_Pos;
    int x = 0;
    int y = 0;
    int z = 0;


    GameObject spawnedObject;
    //GameObject spawned;
    GameObject transparent;
    GameObject Craftframe;
    public GameObject Death;
    CraftFrame craftFrame;

    Rigidbody rd;

    //フラグ
    public bool spawnCount = false;
    public bool craftStart = false;
    public bool craftStart2 = true;
    public bool DeleteOK = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        //spawned = GameObject.Find("AR Session Origin");
        //poss = spawned.transform.position;
        CraftCost = 100;
    }


    // Update is called once per frame
    void Update()
    {
       // spawned.transform.position = poss;
        Cost.text = "" + CraftCost;
        if (spawnCount == true)
        {

            spawnedObject.transform.position = CraftMain;
            transparent.transform.position = CraftMain;

            foreach (ARPlane plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }
        /*if (Input.touchCount == 0)
        {
            return;
        }*/
        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);


        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {


                    if (hit.collider.gameObject.tag == "CraftBlock")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }

                    else if (spawnCount == false)
                    {

                        Main = m_Hits[0].pose.position;
                        F_Pos = Main;
                        //Main.y += 0.03f;
                        CraftMain = Main;

                        Main.z += (c_position * 4);//9*9マスの為

                        for (int I = 1; I <= 9; I++)
                        {

                            Main.x -= (c_position * 5);//9*9マスの為

                            for (int R = 1; R <= 9; R++)
                            {
                                Main.x += c_position;
                                SpawnPrefab(Main);
                            }
                            Main.x -= (c_position * 4);
                            Main.z -= c_position;
                        }


                        _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
                        CraftMain.y += 0.05f;
                        spawnedObject = Instantiate(Frame, CraftMain, Quaternion.identity);
                        transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);
                        spawnCount = true;
                        //poss.x += 0.1f;
                        //Destroy(spawnedObject.GetComponent<Rigidbody>);
                    }
                }

            }





            /*else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
            */
        }


    }
    /*void OnTriggerStay(Collider other)
    {

        craftStart = true;

    }
    void OnTriggerExit(Collider other)
    {
        craftStart = false;
    }
    */

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
    public void UP()
    {
        if (y < 8)
        {
            CraftMain.y += c_position;
            y++;
            //poss.x += 0.1f;
        }
    }
    public void DOWN()
    {
        if (0 < y)
        {
            CraftMain.y -= c_position;
            y--;
        }
    }
    public void FRONT()
    {
        if (-4 < z)
        {
            z--;
            CraftMain.z -= c_position;
        }
    }
    public void BACK()
    {
        if (z < 4)
        {
            CraftMain.z += c_position;
            z++;
        }
    }
    public void LEFT()
    {
        if (-4 < x)
        {
            CraftMain.x -= c_position;
            x--;
        }
    }
    public void RIGHT()
    {
        if (x < 4)
        {
            CraftMain.x += c_position;
            x++;
        }
    }
    public void type1()
    {
        Blocktype = 1;
    }
    public void type2()
    {
        Blocktype = 2;
    }
    public void type3()
    {
        Blocktype = 3;
    }
    public void _king()
    {
        Blocktype = 4;
    }
    public void deleTE()
    {
        if (DeleteOK == true)
        {
            if (ReturnCost == 0)
            {
                king = false;
            }
            Destroy(Death);
            CraftCost += ReturnCost;
            DeleteOK = false;
            craftStart = true;
        }
    }

    public void Craft()
    {

        if (spawnCount == true && craftStart == true)
        {

            if (Blocktype == 1)
            {
                if (CraftCost >= 1)
                {
                    Main = CraftMain;
                    if (y < 8)
                    {
                        y++;
                        CraftMain.y += c_position;
                        GameObject blck=Instantiate(block1, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 1;
                    }
                    else if (y == 8)
                    {
                        GameObject blck = Instantiate(block1, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 1;
                    }
                }
            }
            else if (Blocktype == 2)
            {
                if (CraftCost >= 3)
                {
                    Main = CraftMain;
                    if (y < 8)
                    {
                        y++;
                        CraftMain.y += c_position;
                        GameObject blck= Instantiate(block2, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 3;
                    }
                    else if (y == 8)
                    {
                        GameObject blck = Instantiate(block2, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 3;
                    }
                }
            }
            else if (Blocktype == 3)
            {
                if (CraftCost >= 5)
                {
                    Main = CraftMain;
                    if (y < 8)
                    {
                        y++;
                        CraftMain.y += c_position;
                        GameObject blck=Instantiate(block3, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 5;
                    }
                    else if (y == 8)
                    {
                        GameObject blck = Instantiate(block3, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        CraftCost -= 5;
                    }
                }
            }
            else if (Blocktype == 4)
            {
                if (king == false)
                {
                    Main = CraftMain;
                    if (y < 8)
                    {
                        y++;
                        CraftMain.y += c_position;

                        GameObject blck= Instantiate(King, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd = blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        king = true;
                    }
                    else if (y == 8)
                    {
                        GameObject blck = Instantiate(King, Main, Quaternion.identity);
                        blck.AddComponent<Rigidbody>();
                        rd =blck.GetComponent<Rigidbody>();
                        rd.constraints = RigidbodyConstraints.None;
                        rd.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                        king = true;
                    }
                }
            }
        }
        //craftStart=false;
    }
}
    

