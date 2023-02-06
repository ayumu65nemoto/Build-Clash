using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RainCommand : MonoBehaviourPunCallbacks
{
    public GameObject prefab;
    private int _rainCount;
    //�v���C���[�P�̋��_
    private GameObject _player;
    //�v���C���[�Q�̋��_
    private GameObject _enemy;
    //�v���C���[�P�̈ʒu
    private Transform _target1;
    private Vector3 _targetTransform1;
    //�v���C���[�Q�̈ʒu
    private Transform _target2;
    private Vector3 _targetTransform2;
    //�Q�[���}�l�[�W���[�̎擾
    private GameObject _gameObject;
    private GameManager _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //�G���[����t���O
    private bool _success;
    //SelectUnit�擾
    private SelectUnit _selectUnit;
    private SelectUnit2 _selectUnit2;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        //PhotonConnecter�擾
        _photonConnecter = GameObject.Find("PhotonController").GetComponent<PhotonConnecter>();
        _rainCount = 1;
        _player = GameObject.FindWithTag("Player");
        _enemy = GameObject.FindWithTag("Enemy");
        _target1 = _player.GetComponent<Transform>();
        _target2 = _enemy.GetComponent<Transform>();
        _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
        _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
        _success = false;
        if (_photonConnecter.playerId == 1)
        {
            _selectUnit = GameObject.Find("Canvas").GetComponent<SelectUnit>();
        }
        if (_photonConnecter.playerId == 2)
        {
            _selectUnit2 = GameObject.Find("Canvas2").GetComponent<SelectUnit2>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_rainCount > 0)
        {
            if (_gameManager.p2 == true)
            {
                _player = GameObject.FindWithTag("Player");
                _enemy = GameObject.FindWithTag("Enemy");
                _target1 = _player.GetComponent<Transform>();
                _target2 = _enemy.GetComponent<Transform>();
                _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
                _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
                _success = true;
            }

            if (_photonConnecter.playerId == 1)
            {
                if (_selectUnit.buttonFlag1 == true && _selectUnit.rainShot1 == true)
                {
                    Debug.Log("rain");
                    //�L���O�̈ʒu�ɔ���
                    GameObject rain = PhotonNetwork.Instantiate("Rain", _targetTransform1, Quaternion.Euler(90, 0, 0));
                    _rainCount -= 1;
                    _gameManager.rain1 = true;

                    //// ���ˉ����o��
                    //AudioSource.PlayClipAtPoint(sound, transform.position);
                    _selectUnit.buttonFlag1 = false;
                }
            }

            if (_photonConnecter.playerId == 2)
            {
                if (_selectUnit2.buttonFlag2 == true && _selectUnit2.rainShot2 == true)
                {
                    //�L���O�̈ʒu�ɔ���
                    GameObject rain = PhotonNetwork.Instantiate("Rain", _targetTransform2, Quaternion.Euler(90, 0, 0));
                    _rainCount -= 1;
                    _gameManager.rain2 = true;

                    //// ���ˉ����o��
                    //AudioSource.PlayClipAtPoint(sound, transform.position);
                    _selectUnit2.buttonFlag2 = false;
                }
            }
        }
    }
}
