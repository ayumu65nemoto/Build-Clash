using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RainCommand : MonoBehaviour
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
        _selectUnit = _gameObject.GetComponent<SelectUnit>();
        _selectUnit2 = _gameObject.GetComponent<SelectUnit2>();
        //PhotonConnecter�擾
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
                    //�L���O�̈ʒu�ɔ���
                    GameObject rain = Instantiate(prefab, _targetTransform1, Quaternion.Euler(90, 0, 0));
                    _rainCount -= 1;
                    _gameManager.rain1 = true;

                    //// ���ˉ����o��
                    //AudioSource.PlayClipAtPoint(sound, transform.position);
                    _selectUnit.buttonFlag1 = false;
                }

                if (_selectUnit2.buttonFlag2 == true)
                {
                    //�L���O�̈ʒu�ɔ���
                    GameObject rain = Instantiate(prefab, _targetTransform2, Quaternion.Euler(90, 0, 0));
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
