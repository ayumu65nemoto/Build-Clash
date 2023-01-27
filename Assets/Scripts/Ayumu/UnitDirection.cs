using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDirection : MonoBehaviour
{
    //敵の拠点
    private GameObject _enemy;
    //自分の位置
    private Transform _self;
    //敵の位置
    private Transform _target;
    //ゲームマネージャー
    private GameObject _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //エラー回避フラグ
    private bool _success;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager取得
        _gameManager = GameObject.FindWithTag("GameManager");
        //PhotonConnecter取得
        _photonConnecter = _gameManager.GetComponent<PhotonConnecter>();
        _self = this.transform;
        _success = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonConnecter.p2 == true)
        {
            _enemy = GameObject.FindWithTag("Enemy");
            _target = _enemy.GetComponent<Transform>();
            _success = true;
        }
        if (_success == true)
        {
            _self.LookAt(_target);
        }
    }
}
