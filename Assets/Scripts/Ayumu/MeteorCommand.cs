using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCommand : MonoBehaviour
{
    public GameObject prefab;
    private int _meteorCount;
    //�G�̋��_
    private GameObject _enemy;
    //�G�̈ʒu
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.FindWithTag("Enemy");
        _target = _enemy.GetComponent<Transform>();
        _meteorCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_meteorCount > 0)
        {
            GameObject meteor = Instantiate(prefab, new Vector3(_target.position.x, 10, _target.position.z), Quaternion.identity);
            Rigidbody meteorRb = meteor.GetComponent<Rigidbody>();
            _meteorCount -= 1;

            //// ���ˉ����o��
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(meteor, 2.0f);
        }
    }
}
