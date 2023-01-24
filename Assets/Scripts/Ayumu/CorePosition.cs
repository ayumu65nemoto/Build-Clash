using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CorePosition : MonoBehaviour
{
    private float _posY;
    public TextMeshProUGUI _text;
    //ÉvÉåÉCÉÑÅ[ÇP
    private GameObject _player1;
    private GameObject _p1;

    private GameObject _gameObject;
    private SetBase _setBase;
    private bool _count;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _setBase = _gameObject.GetComponent<SetBase>();
        _count = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_count == true)
        {
            _player1 = GameObject.FindWithTag("PlayerCore");
            _p1 = _player1;
            _count = false;
        }
        _posY = _p1.transform.position.y;

        _text.text = _posY.ToString();
    }
}
