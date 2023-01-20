using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class planeget : MonoBehaviour
{ 
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnablePrefab;
    [SerializeField]
    GameObject Frame;
    bool up;
    bool dawn;
    bool left;
    bool right;
    bool back;
    bool front;

    Vector3 Main;
    Vector3 CraftMain;
    

    Camera arCam;
    GameObject spawnedObject;
    bool spawanCount = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

   
    // Update is called once per frame
    void Update()
    {

        if (spawanCount == true) {  
            
            spawnedObject.transform.position = CraftMain;          
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


                    if (hit.collider.gameObject.tag == "Spawn")
                    {
                        spawnedObject = hit.collider.gameObject;
                    }

                    else if (spawanCount == false)
                    {
                        
                        Main = m_Hits[0].pose.position;
                        CraftMain = Main;
                        for (int I = 1; I <= 9; I++)
                        {
                            Main.z -= 0.1f;
                            
                            Main.x = 0.4f;
                            for (int R = 1; R <= 9; R++)
                            {
                                Main.x -= 0.1f;                         
                                SpawnPrefab(Main);
                            }
                        }
                        
                        CraftMain.y += 0.05f;
                        spawnedObject = Instantiate(Frame, CraftMain, Quaternion.identity);
                        spawanCount = true;
                        
                    }
                }

            }



            

            /*else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            */
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
       

    }
    
    private void SpawnPrefab(Vector3 spawnPosition)
    {
        Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
    public@void UP() 
    {
        CraftMain.y += 0.1f;
    }
    public void DOWN()
    {
        CraftMain.y += -0.1f;
    }
    public void FRONT()
    {
        CraftMain.z += 0.1f;
    }
    public void BACK()
    {
        CraftMain.z += -0.1f;
    }
    public void LEFT()
    {
        CraftMain.x += -0.1f;
    }
    public void RIGHT()
    {
        CraftMain.x += 0.1f;
    }

}
