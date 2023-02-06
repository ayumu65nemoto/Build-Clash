using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCommand2 : MonoBehaviour
{
    private GameObject _gameObject;
    private GameManager _gameManager;
    private SelectUnit2 _selectUnit2;
    private int _commandCount;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _selectUnit2 = GameObject.Find("Canvas").GetComponent<SelectUnit2>();
        _commandCount = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetShot()
    {
        if (_gameManager.battle == true)
        {
            //if (_commandCount > 0)
            //{
            //    _selectUnit.SetUnit(0, 0, 0);
            //    _commandCount -= 1;
            //}
            _selectUnit2.SetUnit(0, 0, 0);
        }
    }
}
