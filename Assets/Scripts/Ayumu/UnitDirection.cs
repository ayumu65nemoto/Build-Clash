using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UnitDirection : MonoBehaviourPunCallbacks
{
    ////�����̋��_
    //private GameObject _player;
    ////�G�̋��_
    //private GameObject _enemy;
    //���j�b�g�̈ʒu
    private Transform _self;
    ////�ݒu����Q�[���I�u�W�F�N�g
    //private GameObject _myObject;
    ////�����̈ʒu
    //private Transform _target1;
    ////�G�̈ʒu
    //private Transform _target2;
    ////�Q�[���}�l�[�W���[
    //private GameObject _gameManager;
    ////PhotonConnecter
    //private PhotonConnecter _photonConnecter;
    ////PhotonView
    //private PhotonView _photonView;
    ////�G���[����t���O
    //private bool _success;

    // Start is called before the first frame update
    void Start()
    {
        ////GameManager�擾
        //_gameManager = GameObject.FindWithTag("GameManager");
        ////PhotonConnecter�擾
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
