using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameShot : MonoBehaviour
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
        _count += 1;

        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (_count % 900 == 0)
        {
            GameObject flame = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody flameRb = flame.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            flameRb.AddForce(transform.forward * 100);

            //// ���ˉ����o��
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // 5�b��ɖC�e��j�󂷂�
            Destroy(flame, 5.0f);
        }
    }
}
