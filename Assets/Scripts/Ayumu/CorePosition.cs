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

    // Start is called before the first frame update
    void Start()
    {
        _player1 = GameObject.FindWithTag("PlayerCore");
    }

    // Update is called once per frame
    void Update()
    {
        _posY = _player1.transform.position.y;

        _text.text = _posY.ToString();
    }
}
