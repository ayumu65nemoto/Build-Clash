using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MeteorCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _meteorCount = 1;
    //�G�̋��_
    private GameObject _enemy;
    //�G�̈ʒu
    private Transform _target;
    //�Q�[���}�l�[�W���[
    private GameObject _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //�G���[����t���O
    private bool _success;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�擾
        _gameManager = GameObject.FindWithTag("GameManager");
        //PhotonConnecter�擾
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

                //// ���ˉ����o��
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // �T�b��ɖC�e��j�󂷂�
                Destroy(meteor, 2.0f);
            }
        }
    }
}
