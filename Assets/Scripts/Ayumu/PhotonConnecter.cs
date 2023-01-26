using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonConnecter : MonoBehaviourPunCallbacks
{
    public int playerId;
    private Vector3 _position;
    private string _prefab;

    private void Start()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
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
            PhotonNetwork.Instantiate(_prefab, _position, Quaternion.identity);
            Debug.Log(playerId);
        }
        if (playerId == 2)
        {
            _position = new Vector3(0, 1.5f, 6);
            _prefab = "EnemyPrefab";
            PhotonNetwork.Instantiate(_prefab, _position, Quaternion.identity);
            Debug.Log(playerId);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName}���Q�����܂���");
    }
}
