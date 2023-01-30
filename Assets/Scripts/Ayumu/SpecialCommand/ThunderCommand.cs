using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ThunderCommand : MonoBehaviourPunCallbacks, IPunObservable
{
    private GameObject[] blocks;
    private PlayerStates _playerStates1;
    private PlayerStates2 _playerStates2;
    private GameObject _playerObject;
    private GameObject _enemyObject;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //エラー回避フラグ
    private bool _success;
    //コマンド回数制限
    private int _thunder;
    //SelectUnit取得
    private SelectUnit _selectUnit;
    private SelectUnit2 _selectUnit2;
    //wetFlag
    public bool wetFlag;
    public bool wetFlag2;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _selectUnit = _gameObject.GetComponent<SelectUnit>();
        _selectUnit2 = _gameObject.GetComponent<SelectUnit2>();
        //PhotonConnecter取得
        _photonConnecter = _gameObject.GetComponent<PhotonConnecter>();
        _playerObject = GameObject.FindWithTag("Player");
        _enemyObject = GameObject.FindWithTag("Enemy");
        _playerStates1 = _playerObject.GetComponent<PlayerStates>();
        _playerStates2 = _enemyObject.GetComponent<PlayerStates2>();
        _thunder = 1;
        wetFlag = false;
        wetFlag2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_thunder > 0)
        {
            if (_photonConnecter.p2 == true)
            {
                _playerObject = GameObject.FindWithTag("Player");
                _enemyObject = GameObject.FindWithTag("Enemy");
                _playerStates1 = _playerObject.GetComponent<PlayerStates>();
                _playerStates2 = _enemyObject.GetComponent<PlayerStates2>();
                _success = true;
            }

            if (_selectUnit.buttonFlag1 == true)
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("Enemy");
                if (wetFlag2 == true)
                {
                    _gameManager.thunder = true;
                    _thunder -= 1;
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject block = blocks[Random.Range(0, 27)];
                        Debug.Log(block);
                        Destroy(block);
                    }
                    Debug.Log("thunder");
                }
            }

            if (_selectUnit2.buttonFlag2 == true)
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("Player");
                if (wetFlag == true)
                {
                    _gameManager.thunder = true;
                    _thunder -= 1;
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject block = blocks[Random.Range(0, 27)];
                        Debug.Log(block);
                        Destroy(block);
                    }
                    Debug.Log("thunder2");
                }
            }
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    //データの送信
        //    //stream.SendNext(wetFlag);
        //}
        //else
        //{
        //    //データの受信
        //    wetFlag = (bool)stream.ReceiveNext();
        //    wetFlag2 = (bool)stream.ReceiveNext();
        //}

        //データの受信
        wetFlag = (bool)stream.ReceiveNext();
        wetFlag2 = (bool)stream.ReceiveNext();
    }
}
