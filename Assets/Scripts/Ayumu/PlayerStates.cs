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
    }

    public PlayerState _state;
    private Rigidbody _rb;
    //�Q�[���}�l�[�W���[�̎擾
    private GameObject _gameObject;
    private GameManager _gameManager;
    //WetFlag
    public bool wetFlag;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        wetFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(PlayerState tempState, Transform targetObj = null)
    {
        _state = tempState;

        if (tempState == PlayerState.Flame)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(this.gameObject, 5f);
        }

        if (tempState == PlayerState.Wet)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            //���ʂ�10�v���X����
            _rb.mass += 100;
            wetFlag = true;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //�f�[�^�̑��M
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.r);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.g);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.b);
            stream.SendNext(gameObject.GetComponent<Renderer>().material.color.a);
        }
        else
        {
            //�f�[�^�̎�M
            float r = (float)stream.ReceiveNext();
            float g = (float)stream.ReceiveNext();
            float b = (float)stream.ReceiveNext();
            float a = (float)stream.ReceiveNext();
            gameObject.GetComponent<Renderer>().material.color = new Vector4(r, g, b, a);
        }
    }
}
