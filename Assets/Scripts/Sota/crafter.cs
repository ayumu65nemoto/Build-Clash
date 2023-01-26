using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField] 
    TextMeshProUGUI Cost;

    bool up;
    bool dawn;
    bool left;
    bool right;
    bool back;
    bool front;
    int  Blocktype = 1;
    int CraftCost;
    public int ReturnCost;

    Vector3 Main;
    public Vector3 CraftMain;
    public Vector3 Once ;


    Camera arCam;
    GameObject spawnedObject;//　フレーム移動
    GameObject transparent;　//ブロック回収用
    GameObject Craftframe; //未使用
    public GameObject Death;
    CraftFrame craftFrame;
    bool spawanCount = false;
    public bool craftStart = false;
    public bool craftStart2 = true;　//未使用
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

        Cost.text = "" + CraftCost;//コスト表示
        if (spawanCount == true)
        {

            spawnedObject.transform.position = CraftMain;//フレーム移動表示
            transparent.transform.position = CraftMain;

            foreach (ARPlane plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);　//ARプレーン非表示
            }
        }
        /*if (Input.touchCount == 0)
        {
            return;
        }*/
        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))　//画面タップ時
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {


                    if (hit.collider.gameObject.tag == "CraftBlock")//無関係
                    {
                        spawnedObject = hit.collider.gameObject;
                    }

                    else if (spawanCount == false)
                    {

                        Main = m_Hits[0].pose.position;
                        //Main.y += 0.03f;
                        CraftMain = Main;
                        
                        Main.z += 0.4f;

                        for (int I = 1; I <= 9; I++)
                        {

                            Main.x += -0.5f;

                            for (int R = 1; R <= 9; R++)
                            {
                                Main.x += 0.1f;
                                SpawnPrefab(Main);//グリッド表示
                            }
                            Main.x += -0.4f;
                            Main.z -= 0.1f;
                        }

                        
                        _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;　//平面認識終了
                        CraftMain.y += 0.0527f;
                        spawnedObject = Instantiate(Frame, CraftMain, Quaternion.identity);　　//フレーム表示
                        transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);　
                        spawanCount = true;                                                         //生成許可
                        
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

    private void SpawnPrefab(Vector3 spawnPosition)　//ブロック生成
    {
        Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
    public void UP()　//フレーム移動
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
    public void deleTE()
    {
        if (DeleteOK==true)　　//ブロック回収
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

                if (Blocktype == 1)//ブロック判別
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
