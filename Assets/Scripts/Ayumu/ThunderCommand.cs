using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCommand : MonoBehaviour
{
    private GameObject[] blocks;
    private PlayerStates _playerStates;
    private GameObject _enemyObject;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    //コマンド回数制限
    private int _thunder;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _enemyObject = GameObject.FindWithTag("Enemy");
        _playerStates = _enemyObject.GetComponent<PlayerStates>();
        _thunder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Enemy");
        if (_thunder > 0)
        {
            if (_playerStates.wetFlag == true)
            {
                _gameManager.thunder = true;
                _thunder -= 1;
                //Destroy(blocks[Random.Range(0, 27)]);
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
