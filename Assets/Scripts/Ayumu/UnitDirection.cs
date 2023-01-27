using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UnitDirection : MonoBehaviourPunCallbacks
{
    ////自分の拠点
    //private GameObject _player;
    ////敵の拠点
    //private GameObject _enemy;
    //ユニットの位置
    private Transform _self;
    ////設置するゲームオブジェクト
    //private GameObject _myObject;
    ////自分の位置
    //private Transform _target1;
    ////敵の位置
    //private Transform _target2;
    ////ゲームマネージャー
    //private GameObject _gameManager;
    ////PhotonConnecter
    //private PhotonConnecter _photonConnecter;
    ////PhotonView
    //private PhotonView _photonView;
    ////エラー回避フラグ
    //private bool _success;

    // Start is called before the first frame update
    void Start()
    {
        ////GameManager取得
        //_gameManager = GameObject.FindWithTag("GameManager");
        ////PhotonConnecter取得
        //_photonConnecter = _gameManager.GetComponent<PhotonConnecter>();
        _self = this.transform;
        //_myObject = this.gameObject;
        //_success = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (_photonConnecter.p2 == true)
        //{
        //    _player = GameObject.FindWithTag("Player");
        //    _enemy = GameObject.FindWithTag("Enemy");
        //    _target1 = _player.GetComponent<Transform>();
        //    _target2 = _enemy.GetComponent<Transform>();
        //    _photonView = _myObject.GetComponent<PhotonView>();

        //    _success = true;
        //}
        //if (_success == true)
        //{
            
        //}
    }

    void OnTriggerStay(Collider col)
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
