using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MeteorCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _meteorCount = 1;
    //vC[PΜ_
    private GameObject _player;
    //vC[QΜ_
    private GameObject _enemy;
    //vC[PΜΚu
    private Transform _target1;
    private Vector3 _targetTransform1;
    //vC[QΜΚu
    private Transform _target2;
    private Vector3 _targetTransform2;
    //Q[}l[W[
    private GameObject _gameManager;
    private GameManager _gameManagerScript;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //G[ρπtO
    private bool _success;
    //SelectUnitζΎ
    private SelectUnit _selectUnit;
    private SelectUnit2 _selectUnit2;

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerζΎ
        _gameManager = GameObject.FindWithTag("GameManager");
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        //PhotonConnecterζΎ
        _photonConnecter = GameObject.Find("PhotonController").GetComponent<PhotonConnecter>();
        _selectUnit = GameObject.Find("Canvas").GetComponent<SelectUnit>();
        _selectUnit2 = GameObject.Find("Canvas2").GetComponent<SelectUnit2>();
        _player = GameObject.FindWithTag("Player");
        _enemy = GameObject.FindWithTag("Enemy");
        _target1 = _player.GetComponent<Transform>();
        _target2 = _enemy.GetComponent<Transform>();
        _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
        _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
        _success = false;
        _meteorCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_meteorCount > 0)
        {
            if (_gameManagerScript.p2 == true)
            {
                _player = GameObject.FindWithTag("Player");
                _enemy = GameObject.FindWithTag("Enemy");
                _target1 = _player.GetComponent<Transform>();
                _target2 = _enemy.GetComponent<Transform>();
                _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
                _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
                _success = true;
            }

            if (_selectUnit.buttonFlag1 == true)
            {
                GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target2.position.x, 10, _target2.position.z), Quaternion.identity);
                //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
                Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
                _meteorCount -= 1;

                //// ­ΛΉπo·
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // TbγΙCeπjσ·ι
                Destroy(meteor, 2.0f);
                _selectUnit.buttonFlag1 = false;
                Debug.Log("a");
            }

            if (_selectUnit2.buttonFlag2 == true)
            {
                GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target1.position.x, 10, _target1.position.z), Quaternion.identity);
                //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
                Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
                _meteorCount -= 1;

                //// ­ΛΉπo·
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // TbγΙCeπjσ·ι
                Destroy(meteor, 2.0f);
                _selectUnit2.buttonFlag2 = false;
            }
        }
    }
}
