using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerStates : MonoBehaviourPunCallbacks, IPunObservable
{
    public enum PlayerState
    {
        Normal,
        Flame,
        Wet,
        Thunder
    }

    public PlayerState state;
    private Rigidbody _rb;
    //ゲームマネージャーの取得
    private GameObject _gameObject;
    private GameManager _gameManager;
    public bool wetFlag;
    //確率用変数
    private int _number;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        wetFlag = false;
        //１から１００のランダムな数字を取る
        _number = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(PlayerState tempState, Transform targetObj = null)
    {
        state = tempState;

        if (tempState == PlayerState.Flame)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(this.gameObject, 5f);
        }

        if (tempState == PlayerState.Wet)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            //質量を10プラスする
            _rb.mass += 100;
            wetFlag = true;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.r);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.g);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.b);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.a);
            stream.SendNext(wetFlag);
            stream.SendNext(state);
        }
        else
        {
            //データの受信
            float r = (float)stream.ReceiveNext();
            float g = (float)stream.ReceiveNext();
            float b = (float)stream.ReceiveNext();
            float a = (float)stream.ReceiveNext();
            wetFlag = (bool)stream.ReceiveNext();
            state = (PlayerState)stream.ReceiveNext();
            gameObject.GetComponent<Renderer>().material.color = new Vector4(r, g, b, a);
        }
    }
}
