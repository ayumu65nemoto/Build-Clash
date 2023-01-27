using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDirection : MonoBehaviour
{
    //�G�̋��_
    private GameObject _enemy;
    //�����̈ʒu
    private Transform _self;
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
