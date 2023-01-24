using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class crafter : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    ARPlaneManager _arPlaneManager;
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

    bool up;
    bool dawn;
    bool left;
    bool right;
    bool back;
    bool front;
    int  Blocktype = 1;

    Vector3 Main;
    Vector3 CraftMain;


    Camera arCam;
    GameObject spawnedObject;
    GameObject transparent;
    GameObject Craftframe;
    CraftFrame craftFrame;
    bool spawanCount = false;
    public bool craftStart = false;
    public bool craftStart2 = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        
        if (spawanCount == true)
        {

            spawnedObject.transform.position = CraftMain;
            //transparent.transform.position = CraftMain;

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
                        Main.y += 0.03f;
                        CraftMain = Main;
                        Main.z += 0.4f;

                        for (int I = 1; I <= 9; I++)
                        {

                            Main.x += -0.5f;

                            for (int R = 1; R <= 9; R++)
                            {
                                Main.x += 0.1f;
                                SpawnPrefab(Main);
                            }
                            Main.x += -0.4f;
                            Main.z -= 0.1f;
                        }


                        _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
                        CraftMain.y += 0.05f;
                        spawnedObject = Instantiate(Frame, CraftMain, Quaternion.identity);
                        //transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);
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
        CraftMain.y += 0.1f;
    }
    public void DOWN()
    {
        CraftMain.y += -0.1f;
    }
    public void FRONT()
    {
        CraftMain.z += -0.1f;
    }
    public void BACK()
    {
        CraftMain.z += 0.1f;
    }
    public void LEFT()
    {
        CraftMain.x += -0.1f;
    }
    public void RIGHT()
    {
        CraftMain.x += 0.1f;
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

    public void Craft()
    {
        if (spawanCount == true && craftStart == true)
        {
            if (Blocktype == 1)
            {
                Instantiate(block1, CraftMain, Quaternion.identity);
            }
            else if(Blocktype==2)
            {
                Instantiate(block2, CraftMain, Quaternion.identity);
            }
            else if (Blocktype == 3)
            {
                Instantiate(block3, CraftMain, Quaternion.identity);
            }
            craftStart=false;
        }
    }
    /*void masterC()
    {
        Craftframe = GameObject.Find("CraftFrame");
        craftFrame = Craftframe.GetComponent<CraftFrame>();
    }*/
}
