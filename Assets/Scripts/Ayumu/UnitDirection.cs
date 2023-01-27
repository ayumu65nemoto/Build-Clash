using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UnitDirection : MonoBehaviourPunCallbacks
{
    //ユニットの位置
    private Transform _self;
    //設置するゲームオブジェクト
    private GameObject _myObject;
    //PhotonView
    private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _self = this.transform;
        _myObject = this.gameObject;
        _photonView = _myObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        _self = this.transform;
        _myObject = this.gameObject;
        _photonView = _myObject.GetComponent<PhotonView>();

        if (_photonView.IsMine)
        {
            if (col.tag == "Player")
            {
                _self.LookAt(col.transform);
            }

            if (col.tag == "Enemy")
            {
                _self.LookAt(col.transform);
            }
        }
    }
}
