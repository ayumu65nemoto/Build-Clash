using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;
    private PlayerStates _playerState;
    private GameObject _enemyObject;
    private GameObject _rain;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _enemyObject = GameObject.FindWithTag("Enemy");
        _playerStates = _enemyObject.GetComponent<PlayerStates>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.rain == true)
        {
            // タグが同じオブジェクトを全て取得する
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject gameObj in gameObjects)
            {
                _playerState = gameObj.GetComponent<PlayerStates>();
                _playerState.SetState(PlayerStates.PlayerState.Wet);
            }
            _gameManager.rain = false;
        }
    }

    ////　当たったら時間経過で破壊する
    //private void oncollisionenter(collision collision)
    //{
    //    //if (_playerstates.wetflag != true)
    //    //{
    //    //    if (collision.gameobject.comparetag("flame"))
    //    //    {
    //    //        gameobject[] gameobjects = gameobject.findgameobjectswithtag("enemy");
    //    //        foreach (gameobject gameobj in gameobjects)
    //    //        {
    //    //            _playerstates = gameobj.getcomponent<playerstates>();
    //    //        }
    //    //        _playerstates.setstate(playerstates.playerstate.flame);
    //    //    }
    //    //}
    //    debug.log("flame");
    //    _playerstates.setstate(playerstates.playerstate.flame);
    //}
}
