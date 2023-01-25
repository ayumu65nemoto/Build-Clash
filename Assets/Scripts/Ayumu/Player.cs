using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;
    private PlayerStates _playerState;
    private GameObject _enemyObject;
    private GameObject _rain;
    //�Q�[���}�l�[�W���[�̎擾
    private GameObject _gameObject;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //_enemyObject = GameObject.FindWithTag("Enemy");
        //_playerStates = _enemyObject.GetComponent<PlayerStates>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.rain == true)
        {
            // �^�O�������I�u�W�F�N�g��S�Ď擾����
            //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            //foreach (GameObject gameObj in gameObjects)
            //{
            //    _playerState = gameObj.GetComponent<PlayerStates>();
            //    _playerState.SetState(PlayerStates.PlayerState.Wet);
            //}
            _gameManager.rain = false;
        }
    }
}
