using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonConnecter : MonoBehaviourPunCallbacks
{
    //プレイヤーID(擬似取得)
    public int playerId;
    ////キャンバス表示フラグ
    //public bool canvasFlag;
    //public bool canvasFlag2;
    ////相手プレイヤー出現フラグ
    //public bool p1;
    //public bool p2;

    //接続フラグ
    public bool connect;

    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        //canvasFlag = false;
        //canvasFlag2 = false;
        //p1 = false;
        //p2 = false;
        connect = false;
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
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
        Debug.Log($"{newPlayer.NickName}が参加しました");
    }
}