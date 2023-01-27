using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;
    private PlayerStates _playerStates2;
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
        _photonConnecter = _gameObject.GetComponent<PhotonConnecter>();
        _success = false;
    }

    void Update()
    {
        if (_photonConnecter.p2 == true)
        {
            _enemyObject = GameObject.FindWithTag("Enemy");
            _playerStates = _enemyObject.GetComponent<PlayerStates>();
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
                _playerStates2 = gameObj.GetComponent<PlayerStates>();
                _playerStates2.SetState(PlayerStates.PlayerState.Wet);
            }
            _gameManager.rain2 = false;
        }
    }
}
