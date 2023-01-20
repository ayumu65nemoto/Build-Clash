using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDirection : MonoBehaviour
{
    //敵の拠点
    private GameObject _enemy;
    //自分の位置
    private Transform _self;
    //敵の位置
    private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _self = this.transform;
        _enemy = GameObject.FindWithTag("Enemy");
        _target = _enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _self.LookAt(_target);
    }
}
