using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //�v���n�u�����������Z�b�g
        //    GameObject ball = GameObject.Instantiate(prefab) as GameObject;
        //    //�}�E�X�N���b�N�����n�_�ɋ����΂�
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Vector3 dir = ray.direction;
        //    //���ɗ͂�������
        //    ball.GetComponent<Rigidbody>().AddForce(dir * 2000);
        //}

        _count += 1;

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
