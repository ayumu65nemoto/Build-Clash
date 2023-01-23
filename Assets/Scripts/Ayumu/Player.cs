using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;
    private GameObject _rain;
    //�Q�[���}�l�[�W���[�̎擾
    private GameObject _gameObject;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerStates = GetComponent<PlayerStates>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.rain == true)
        {
            _playerStates.SetState(PlayerStates.PlayerState.Wet);
            //_gameManager.rain = false;
        }
    }

    //�@���������玞�Ԍo�߂Ŕj�󂷂�j�󂷂�
    private void OnCollisionEnter(Collision collision)
    {
        if (_playerStates._state != PlayerStates.PlayerState.Wet)
        {
            if (collision.gameObject.CompareTag("Flame"))
            {
                _playerStates.SetState(PlayerStates.PlayerState.Flame);
            }
        }
    }
}
