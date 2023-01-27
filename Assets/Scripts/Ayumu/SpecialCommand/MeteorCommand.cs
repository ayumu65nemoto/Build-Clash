using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MeteorCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _meteorCount = 1;
    //ƒvƒŒƒCƒ„[‚P‚Ì‹’“_
    private GameObject _player;
    //ƒvƒŒƒCƒ„[‚Q‚Ì‹’“_
    private GameObject _enemy;
    //ƒvƒŒƒCƒ„[‚P‚ÌˆÊ’u
    private Transform _target1;
    private Vector3 _targetTransform1;
    //ƒvƒŒƒCƒ„[‚Q‚ÌˆÊ’u
    private Transform _target2;
    private Vector3 _targetTransform2;
    //ƒQ[ƒ€ƒ}ƒl[ƒWƒƒ[
    private GameObject _gameManager;
    //PhotonConnecter
    private PhotonConnecter _photonConnecter;
    //ƒGƒ‰[‰ñ”ğƒtƒ‰ƒO
    private bool _success;
    //SelectUnitæ“¾
    private SelectUnit _selectUnit;
    private SelectUnit2 _selectUnit2;

    // Start is called before the first frame update
    void Start()
    {
        //GameManageræ“¾
        _gameManager = GameObject.FindWithTag("GameManager");
        //PhotonConnecteræ“¾
        _photonConnecter = _gameManager.GetComponent<PhotonConnecter>();
        _selectUnit = _gameManager.GetComponent<SelectUnit>();
        _selectUnit2 = _gameManager.GetComponent<SelectUnit2>();
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
            if (_photonConnecter.p2 == true)
            {
                _player = GameObject.FindWithTag("Player");
                _enemy = GameObject.FindWithTag("Enemy");
                _target1 = _player.GetComponent<Transform>();
                _target2 = _enemy.GetComponent<Transform>();
                _targetTransform1 = new Vector3(_target1.position.x, _target1.position.y + 10, _target1.position.z);
                _targetTransform2 = new Vector3(_target2.position.x, _target2.position.y + 10, _target2.position.z);
                _success = true;
            }

            //if (_success == true)
            //{
            //    if (_selectUnit.buttonFlag1 == true)
            //    {
            //        GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target2.position.x, 10, _target2.position.z), Quaternion.identity);
            //        //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
            //        Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
            //        _meteorCount -= 1;

            //        //// ”­Ë‰¹‚ğo‚·
            //        //AudioSource.PlayClipAtPoint(sound, transform.position);

            //        // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
            //        Destroy(meteor, 2.0f);
            //        _selectUnit.buttonFlag1 = false;
            //        Debug.Log("a");
            //    }

            //    if (_selectUnit2.buttonFlag2 == true)
            //    {
            //        GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target1.position.x, 10, _target1.position.z), Quaternion.identity);
            //        //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
            //        Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
            //        _meteorCount -= 1;

            //        //// ”­Ë‰¹‚ğo‚·
            //        //AudioSource.PlayClipAtPoint(sound, transform.position);

            //        // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
            //        Destroy(meteor, 2.0f);
            //        _selectUnit2.buttonFlag2 = false;
            //    }
            //    Debug.Log(_meteorCount);
            //}

            if (_selectUnit.buttonFlag1 == true)
            {
                GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(_target2.position.x, 10, _target2.position.z), Quaternion.identity);
                //GameObject meteor = PhotonNetwork.Instantiate("Meteor", new Vector3(0, 10, 0), Quaternion.identity);
                Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
                _meteorCount -= 1;

                //// ”­Ë‰¹‚ğo‚·
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
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

                //// ”­Ë‰¹‚ğo‚·
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
                Destroy(meteor, 2.0f);
                _selectUnit2.buttonFlag2 = false;
            }
        }
    }
}
