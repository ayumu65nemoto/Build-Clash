using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int count;

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

        count += 1;

        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (count % 420 == 0)
        {
            GameObject shell = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            shellRb.AddForce(transform.forward * 1000);

            //// ���ˉ����o��
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(shell, 5.0f);
        }
    }
}
