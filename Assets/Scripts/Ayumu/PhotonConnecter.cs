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
    //拠点を置く位置
    private Vector3 _position;
    //設置する拠点
    private string _prefab;
    //表示するUI
    private GameObject _canvas;
    private GameObject _canvas2;
    //キャンバス表示フラグ
    public bool canvasFlag;
    public bool canvasFlag2;
    //相手プレイヤー出現フラグ
    public bool p1;
    public bool p2;

    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
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
        Debug.Log($"{newPlayer.NickName}が参加しました");
    }
}