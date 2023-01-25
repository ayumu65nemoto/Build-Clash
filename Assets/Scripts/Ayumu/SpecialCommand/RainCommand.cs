using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RainCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _rainCount;
    //敵の拠点
    private GameObject _enemy;
    //敵の位置
    private Transform _target;
    private Vector3 _targetTransform;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _rainCount = 1;
        //_enemy = GameObject.FindWithTag("Enemy");
        //_target = _enemy.GetComponent<Transform>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        //_targetTransform = new Vector3(_target.position.x, _target.position.y + 10, _target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rainCount > 0)
        {
            ////キングの位置に発生
            //GameObject rain = Instantiate(prefab, _targetTransform, Quaternion.Euler(90, 0, 0));
            GameObject rain = PhotonNetwork.Instantiate("Rain", new Vector3(0, 10, 0), Quaternion.Euler(90, 0, 0));
            //Rigidbody meteorRb = rain.GetComponent<Rigidbody>();
            _rainCount -= 1;
            _gameManager.rain = true;

            //// 発射音を出す
            //AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
