using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonConnecter : MonoBehaviourPunCallbacks
{
    //�v���C���[ID(�[���擾)
    public int playerId;
    //���_��u���ʒu
    private Vector3 _position;
    //�ݒu���鋒�_
    private string _prefab;
    //�\������UI
    private GameObject _canvas;
    private GameObject _canvas2;
    //�L�����o�X�\���t���O
    public bool canvasFlag;
    public bool canvasFlag2;
    //����v���C���[�o���t���O
    public bool p1;
    public bool p2;

    private void Start()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        //if (SceneManager.GetActiveScene().name == "Battle")
        _canvas = GameObject.FindWithTag("Canvas");
        _canvas2 = GameObject.FindWithTag("Canvas2");
        _canvas.SetActive(false);
        _canvas2.SetActive(false);
        canvasFlag = false;
        canvasFlag2 = false;
        p1 = false;
        p2 = false;
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerId = player.ActorNumber;
        }

        if (playerId == 1)
        {
            _position = new Vector3(0, 1.5f, -10);
            _prefab = "PlayerPrefab";
            _canvas.SetActive(true);
            canvasFlag = true;
            p1 = true;
            PhotonNetwork.Instantiate(_prefab, _position, Quaternion.identity);
            Debug.Log(playerId);
        }
        if (playerId == 2)
        {
            _position = new Vector3(0, 1.5f, 6);
            _prefab = "EnemyPrefab";
            _canvas2.SetActive(true);
            canvasFlag2 = true;
            p2 = true;
            PhotonNetwork.Instantiate(_prefab, _position, Quaternion.identity);
            Debug.Log(playerId);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}���Q�����܂���");
    }
}