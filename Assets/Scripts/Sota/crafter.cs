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
    GameObject DeleteTool;
    [SerializeField] 
    TextMeshProUGUI Cost;

    //クラフトメイン
    int  Blocktype = 1;
    int CraftCost;
    public int ReturnCost;
    float c_position = 0.1f;
    Vector3 Main;
    public Vector3 CraftMain;
    public Vector3 Once ;


    
    GameObject spawnedObject;
    GameObject transparent;
    GameObject Craftframe;
    public GameObject Death;
    CraftFrame craftFrame;

    //フラグ
    bool spawanCount = false;
    public bool craftStart = false;
    public bool craftStart2 = true;
    public bool DeleteOK = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        CraftCost = 100;
    }


    // Update is called once per frame
    void Update()
    {

        Cost.text = "" + CraftCost;
        if (spawanCount == true)
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

                    else if (spawanCount == false)
                    {

                        Main = m_Hits[0].pose.position;
                        //Main.y += 0.03f;
                        CraftMain = Main;
                        
                        Main.z += (c_position*5);//9*9マスの為

                        for (int I = 1; I <= 9; I++)
                        {

                            Main.x -= (c_position*5);//9*9マスの為

                            for (int R = 1; R <= 9; R++)
                            {
                                Main.x += c_position;
                                SpawnPrefab(Main);
                            }
                            Main.x -= (c_position*4);
                            Main.z -= c_position;
                        }


                        _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
                        CraftMain.y += 0.05f;
                        spawnedObject = Instantiate(Frame, CraftMain, Quaternion.identity);
                        transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);
                        spawanCount = true;
                        
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
        CraftMain.y += c_position;
    }
    public void DOWN()
    {
        CraftMain.y -= c_position;
    }
    public void FRONT()
    {
        CraftMain.z -= c_position;
    }
    public void BACK()
    {
        CraftMain.z += c_position;
    }
    public void LEFT()
    {
        CraftMain.x -= c_position;
    }
    public void RIGHT()
    {
        CraftMain.x += c_position;
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
    public void deleTE()
    {
        if (DeleteOK==true)
        {
            Destroy(Death);
            CraftCost += ReturnCost;
            DeleteOK = false;
        }
    }

    public void Craft()
    {
        
        if (spawanCount == true && craftStart == true)
        {
            
            if (Once!=CraftMain)
            {

                if (Blocktype == 1)
                {
                    if (CraftCost >= 1)
                    {
                        Main = CraftMain;
                        CraftMain.y += 0.1f;
                        Instantiate(block1, Main, Quaternion.identity);
                        CraftCost -= 1;
                    }
                }
                else if (Blocktype == 2)
                {
                    if (CraftCost >= 3)
                    {
                        Main = CraftMain;
                        CraftMain.y += 0.1f;
                        Instantiate(block2, Main, Quaternion.identity);
                        CraftCost -= 3;
                    }
                }
                else if (Blocktype == 3)
                {
                    if (CraftCost >= 5)
                    {
                        Main = CraftMain;
                        CraftMain.y += 0.1f;
                        Instantiate(block3, Main, Quaternion.identity);
                        CraftCost -= 5;
                    }
                }
            }
            //craftStart=false;
        }
    }
    
}
