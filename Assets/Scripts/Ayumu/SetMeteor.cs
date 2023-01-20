using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMeteor : MonoBehaviour
{
    private GameObject _gameObject;
    private GameManager _gameManager;
    private SelectUnit _selectUnit;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _selectUnit = _gameObject.GetComponent<SelectUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Meteor()
    {
        if (_gameManager.battle == true)
        {
            _selectUnit.SetUnit(0, 0, 0);
        }
    }
}
