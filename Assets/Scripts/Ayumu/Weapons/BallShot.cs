using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private GameObject _gameObject;
    private GameManager _gameManager;

    SelectUnit select;

    

    //???ˉ?
    [SerializeField] private AudioClip cannon;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        select = _gameManager.GetComponent<SelectUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        _count += 1;

        if (_gameManager.battle == true)
        {
            // 420?t???[?????ƂɖC?e?𔭎˂???
            if (_count % 40 == 0)
            {
                GameObject ball = PhotonNetwork.Instantiate("Ball", transform.position, Quaternion.identity);
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();

                // ?e???͎??R?ɐݒ?
                ballRb.AddForce(transform.forward * 40, ForceMode.Impulse);

                // ???ˉ????o??
                AudioSource.PlayClipAtPoint(cannon, transform.position);

                // ?T?b???ɖC?e???j?󂷂?
                Destroy(ball, 2.0f);
            }
        }
    }
}
