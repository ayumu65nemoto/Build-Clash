using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class CastleSpawn : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    ARPlaneManager _arPlaneManager;
    Camera arCam;

    [SerializeField]
    GameObject Plane;

    GameObject Listsaver;
    ListSaver ListS;

    Vector3 CastleMain;
    Vector3 SC_pos;

    bool castlespawn = false;

    // Start is called before the first frame update
    void Start()
    {
        Listsaver = GameObject.Find("ListSaver");
        ListS = Listsaver.GetComponent<ListSaver>();
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (castlespawn == true)
        {
            foreach (ARPlane plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);



        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {

            if (Physics.Raycast(ray, out hit))
            {

                if (castlespawn == false)
                {
                    CastleMain = m_Hits[0].pose.position;
                    
                    Instantiate(Plane, CastleMain, Quaternion.identity);
                    CastleMain = m_Hits[0].pose.position;
                    CastleCreate(CastleMain);
                    castlespawn = true;
                    _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;

                    //transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);
                }
            }


        }
    }

    void CastleCreate(Vector3 P_cas)
    {
        
        for (int i = 0; i < ListS.saveList.Count; i++)
        {
            Vector3 sss = ListS.PosList[i];
            sss += P_cas;
            
//            sss.x += P_cas.x;
  //          sss.z += P_cas.z;
            ListS.saveList[i].gameObject.SetActive(true);
            ListS.saveList[i].gameObject.transform.position = sss;        
        }
    }
}
