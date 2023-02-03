using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private int _angle = 90;
    private GameObject _gameObject;
    private GameManager _gameManager;
    //���ˉ�
    [SerializeField] private AudioClip barista;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _count += 1;

        if (_gameManager.battle == true)
        {
            // �U�O�t���[�����ƂɖC�e�𔭎˂���
            if (_count % 40 == 0)
            {
                GameObject arrow = PhotonNetwork.Instantiate("Arrow", transform.position, Quaternion.Euler(_angle, 0, 0));
                Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

                // �e���͎��R�ɐݒ�
                arrowRb.AddForce(transform.forward * 20, ForceMode.Impulse);

                // ���ˉ����o��
                AudioSource.PlayClipAtPoint(barista, transform.position);

                // �T�b��ɖC�e��j�󂷂�
                Destroy(arrow, 2.0f);
            }
        }
    }
}
