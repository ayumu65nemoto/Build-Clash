using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Photon.Pun;
using Photon.Realtime;


public class CastleSpawn : MonoBehaviourPunCallbacks
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
    GameManager _GM;
    SelectUnit _SU;

    public Vector3 CastleMain;
    public Vector3 SC_pos;

    bool castlespawn = false;

    // Start is called before the first frame update
    void Awake()
    {
        Listsaver = GameObject.Find("GameManager");
        _GM = Listsaver.GetComponent<GameManager>();
        _SU = Listsaver.GetComponent<SelectUnit>();
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
                    SC_pos = m_Hits[0].pose.position;
                    CastleMain.y -= 1f;
                    //Instantiate(Plane, CastleMain, Quaternion.identity);
                    CastleMain = m_Hits[0].pose.position;
                    //CastleCreate(CastleMain,1);
                    castlespawn = true;
                    _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
                    _SU.ARget = true;
                    //transparent = Instantiate(DeleteTool, CraftMain, Quaternion.identity);
                }
            }


        }
    }

    //void CastleCreate(Vector3 P_cas,int Qi)
    //{
        
    //    for (int i = 0; i < _GM.myList.Count; i++)
    //    {
    //        Vector3 sss = _GM.PosList[i];
    //        sss += P_cas;
    //        sss.x=sss.x* Qi;
    //        sss.z=sss.z* Qi;
    //        sss.y += 0.1f;

    //        //            sss.x += P_cas.x;
    //        //          sss.z += P_cas.z;
    //        //_GM.myList[i].gameObject.SetActive(true);
    //        //_GM.myList[i].gameObject.transform.position = sss;

    //        PhotonNetwork.Instantiate(_GM.myList[i].name, sss, Quaternion.identity);
    //    }
    //}
}
