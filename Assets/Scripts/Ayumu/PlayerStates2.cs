using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerStates2 : MonoBehaviourPunCallbacks, IPunObservable
{
    public enum PlayerState
    {
        Normal,
        Flame,
        Wet,
        Thunder
    }

    public PlayerState state2;
    private Rigidbody _rb;
    //�Q�[���}�l�[�W���[�̎擾
    private GameObject _gameObject;
    private GameManager _gameManager;
    public bool wetFlag2;
    //�m���p�ϐ�
    private int _number;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        wetFlag2 = false;
        //�P����P�O�O�̃����_���Ȑ��������
        _number = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetState(PlayerState tempState, Transform targetObj = null)
    {
        state2 = tempState;

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
            wetFlag2 = true;
        }

        if (tempState == PlayerState.Thunder)
        {
            if (_number <= 20)
            {
                Destroy(this.gameObject);
            }
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
            stream.SendNext(wetFlag2);
            stream.SendNext(state2);
        }
        else
        {
            //�f�[�^�̎�M
            float r = (float)stream.ReceiveNext();
            float g = (float)stream.ReceiveNext();
            float b = (float)stream.ReceiveNext();
            float a = (float)stream.ReceiveNext();
            wetFlag2 = (bool)stream.ReceiveNext();
            state2 = (PlayerState)stream.ReceiveNext();
            gameObject.GetComponent<Renderer>().material.color = new Vector4(r, g, b, a);
        }
    }
}
