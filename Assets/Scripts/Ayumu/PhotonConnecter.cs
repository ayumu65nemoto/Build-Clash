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
    ////�L�����o�X�\���t���O
    //public bool canvasFlag;
    //public bool canvasFlag2;
    ////����v���C���[�o���t���O
    //public bool p1;
    //public bool p2;

    //�ڑ��t���O
    public bool connect;

    private void Start()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        //canvasFlag = false;
        //canvasFlag2 = false;
        //p1 = false;
        //p2 = false;
        connect = false;
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
            connect = true;
            Debug.Log(playerId);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}���Q�����܂���");
    }
}