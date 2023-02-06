using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;
    private PlayerStates2 _playerStates2;
    private GameObject _playerObject;
    private GameObject _enemyObject;
    private GameObject _rain;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //エラー回避フラグ
    private bool _success;

    // Start is called before the first frame update
    void Start()
    {
        //_enemyObject = GameObject.FindWithTag("Enemy");
        //_playerStates = _enemyObject.GetComponent<PlayerStates>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        //PhotonConnecter取得
        _photonConnecter = GameObject.Find("PhotonController").GetComponent<PhotonConnecter>();
        _success = false;
    }

    void Update()
    {
        if (_gameManager.p2 == true)
        {
            _playerObject = GameObject.FindWithTag("Player");
            _enemyObject = GameObject.FindWithTag("Enemy");
            _playerStates = _playerObject.GetComponent<PlayerStates>();
            _playerStates2 = _enemyObject.GetComponent<PlayerStates2>();
            _success = true;
        }

        if (_gameManager.rain1 == true)
        {
            // タグが同じオブジェクトを全て取得する
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject gameObj in gameObjects)
            {
                _playerStates = gameObj.GetComponent<PlayerStates>();
                _playerStates.SetState(PlayerStates.PlayerState.Wet);
            }
            _gameManager.rain1 = false;
        }

        if (_gameManager.rain2 == true)
        {
            // タグが同じオブジェクトを全て取得する
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject gameObj in gameObjects)
            {
                _playerStates2 = gameObj.GetComponent<PlayerStates2>();
                _playerStates2.SetState(PlayerStates2.PlayerState.Wet);
            }
            _gameManager.rain2 = false;
        }

        if (_gameManager.thunder1 == true)
        {
            // タグが同じオブジェクトを全て取得する
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject gameObj in gameObjects)
            {
                _playerStates2 = gameObj.GetComponent<PlayerStates2>();
                _playerStates2.SetState(PlayerStates2.PlayerState.Thunder);
            }
            _gameManager.thunder1 = false;
        }

        if (_gameManager.thunder2 == true)
        {
            // タグが同じオブジェクトを全て取得する
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject gameObj in gameObjects)
            {
                _playerStates = gameObj.GetComponent<PlayerStates>();
                _playerStates.SetState(PlayerStates.PlayerState.Thunder);
            }
            _gameManager.thunder2 = false;
        }
    }
}
