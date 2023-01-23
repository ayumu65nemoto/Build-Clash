using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private int _angle = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _count += 1;

        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (_count % 180 == 0)
        {
            GameObject arrow = Instantiate(prefab, transform.position, Quaternion.Euler(_angle, 0, 0));
            Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            arrowRb.AddForce(transform.forward * 500);

            //// ���ˉ����o��
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(arrow, 2.0f);
        }
    }
}
