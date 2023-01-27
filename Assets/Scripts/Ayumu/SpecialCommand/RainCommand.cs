using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RainCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _rainCount;
    //プレイヤー１の拠点
    private GameObject _player;
    //プレイヤー２の拠点
    private GameObject _enemy;
    //プレイヤー１の位置
    private Transform _target1;
    private Vector3 _targetTransform1;
    //プレイヤー２の位置
    private Transform _target2;
    private Vector3 _targetTransform2;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //エラー回避フラグ
    private bool _success;
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
        _rainCount = 1;
        _player = GameObject.FindWithTag("Player");
        _enemy = GameObject.FindWithTag("Enemy");
        _target1 = _player.GetComponent<Transform>();
        _target2 = _enemy.GetComponent<Transform>();
        _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
        _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rainCount > 0)
        {
            if (_photonConnecter.p2 == true)
            {
                _player = GameObject.FindWithTag("Player");
                _enemy = GameObject.FindWithTag("Enemy");
                _target1 = _player.GetComponent<Transform>();
                _target2 = _enemy.GetComponent<Transform>();
                _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
                _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
            }
            
            if (_success == true)
            {
                if (_selectUnit.buttonFlag1 == true)
                {
                    //キングの位置に発生
                    GameObject rain = Instantiate(prefab, _targetTransform1, Quaternion.Euler(90, 0, 0));
                    _rainCount -= 1;
                    _gameManager.rain1 = true;

                    //// 発射音を出す
                    //AudioSource.PlayClipAtPoint(sound, transform.position);
                    _selectUnit.buttonFlag1 = false;
                }

                if (_selectUnit2.buttonFlag2 == true)
                {
                    //キングの位置に発生
                    GameObject rain = Instantiate(prefab, _targetTransform2, Quaternion.Euler(90, 0, 0));
                    _rainCount -= 1;
                    _gameManager.rain2 = true;

                    //// 発射音を出す
                    //AudioSource.PlayClipAtPoint(sound, transform.position);
                    _selectUnit2.buttonFlag2 = false;
                }
            }
        }
    }
}
