using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyCore : MonoBehaviourPunCallbacks, IPunObservable
{
    private GameObject _gameObject;
    private GameManager _gameManager;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            _gameManager.isGround2 = true;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(_rb.position);
            stream.SendNext(_rb.rotation);
            stream.SendNext(_rb.velocity);
        }
        else
        {
            //データの受信
            _rb.position = (Vector3)stream.ReceiveNext();
            _rb.rotation = (Quaternion)stream.ReceiveNext();
            _rb.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.timestamp));
            _rb.position += _rb.velocity * lag;
        }
    }
}
