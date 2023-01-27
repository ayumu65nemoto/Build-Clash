using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MeteorCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _meteorCount = 1;
    //敵の拠点
    private GameObject _enemy;
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
        _enemy = GameObject.FindWithTag("Enemy");
        _target = _enemy.GetComponent<Transform>();
        _success = false;
        _meteorCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_meteorCount > 0)
        {
            if (_photonConnecter.p2 == true)
            {
                _enemy = GameObject.FindWithTag("Enemy");
                _target = _enemy.GetComponent<Transform>();
                _success = true;
            }

            if (_success == true)
            {
                GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target.position.x, 10, _target.position.z), Quaternion.identity);
                //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
                Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
                _meteorCount -= 1;

                //// 発射音を出す
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // ５秒後に砲弾を破壊する
                Destroy(meteor, 2.0f);
            }
        }
    }
}
