using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private GameObject _gameObject;
    private GameManager _gameManager;

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
            if (_count % 420 == 0)
            {
                GameObject ball = Instantiate(prefab, transform.position, Quaternion.identity);
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();

                // �e���͎��R�ɐݒ�
                ballRb.AddForce(transform.forward * 1000);

                //// ���ˉ����o��
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // �T�b��ɖC�e��j�󂷂�
                Destroy(ball, 2.0f);
            }
        }
    }
}