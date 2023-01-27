using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCommand : MonoBehaviour
{
    private GameObject[] blocks;
    private PlayerStates _playerStates1;
    private PlayerStates _playerStates2;
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
        _playerStates2 = _enemyObject.GetComponent<PlayerStates>();
        _thunder = 1;
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
                _playerStates2 = _enemyObject.GetComponent<PlayerStates>();
                _success = true;
            }

            if (_success == true)
            {
                if (_selectUnit.buttonFlag1 == true)
                {
                    GameObject[] blocks = GameObject.FindGameObjectsWithTag("Enemy");
                    if (_playerStates2.wetFlag == true)
                    {
                        _gameManager.thunder = true;
                        _thunder -= 1;
                        for (int i = 0; i < 5; i++)
                        {
                            GameObject block = blocks[Random.Range(0, 27)];
                            Debug.Log(block);
                            Destroy(block);
                        }
                    }
                }

                if (_selectUnit2.buttonFlag2 == true)
                {
                    GameObject[] blocks = GameObject.FindGameObjectsWithTag("Player");
                    if (_playerStates1.wetFlag == true)
                    {
                        _gameManager.thunder = true;
                        _thunder -= 1;
                        for (int i = 0; i < 5; i++)
                        {
                            GameObject block = blocks[Random.Range(0, 27)];
                            Debug.Log(block);
                            Destroy(block);
                        }
                    }
                }
            }
        }
    }
}
