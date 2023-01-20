using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDirection : MonoBehaviour
{
    //“G‚Ì‹’“_
    private GameObject _enemy;
    //Ž©•ª‚ÌˆÊ’u
    private Transform _self;
    //“G‚ÌˆÊ’u
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
