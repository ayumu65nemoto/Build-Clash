using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SelectUnit : MonoBehaviourPunCallbacks
{
    //ユニット格納
    [SerializeField] public GameObject[] units;
    //ユニット番号
    public int selectUnitNumber;
    //ボタンフラグ
    public bool push_a = false;
    public bool push_b = false;
    public bool push_c = false;
    //矢印格納
    public GameObject[] indicater_a;
    public GameObject[] indicater_b;
    public GameObject[] indicater_c;
    //矢印本体
    public GameObject _indicater0;
    public GameObject _indicater1;
    public GameObject _indicater2;
    public GameObject _indicater3;
    public GameObject _indicater4;
    public GameObject _indicater5;
    public GameObject _indicater6;
    public GameObject _indicater7;
    public GameObject _indicater8;
    //キャンバス確認のためにPhotonConnecterを取得
    private PhotonConnecter _photonConnecter;
    //1Pと2Pを区別するためのフラグ
    public bool buttonFlag1;
    //雨のコマンドをどちらが押したのか
    public bool rainShot1;
    //GameManager
    private GameManager _gameManager;

    //AR用に追加
    CastleSpawn UnitSpawn;
    public Vector3 Qii;

    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber = 0;

        //PhotonConnecter取得
        _photonConnecter = GetComponent<PhotonConnecter>();
        //AR用に追加
        UnitSpawn = gameObject.GetComponent<CastleSpawn>();

        buttonFlag1 = false;
        rainShot1 = false;

        _gameManager = GetComponent<GameManager>();
    }

    public void PushDownA()
    {
        push_a = true;
        selectUnitNumber = 0;
        indicater_a[0].SetActive(true);
        indicater_a[1].SetActive(true);
        indicater_a[2].SetActive(true);
    }

    public void PushDownB()
    {
        push_b = true;
        selectUnitNumber = 1;
        indicater_b[0].SetActive(true);
        indicater_b[1].SetActive(true);
        indicater_b[2].SetActive(true);
    }

    public void PushDownC()
    {
        push_c = true;
        selectUnitNumber = 2;
        indicater_c[0].SetActive(true);
        indicater_c[1].SetActive(true);
        indicater_c[2].SetActive(true);
    }

    public void PushDownD()
    {
        selectUnitNumber = 3;
        buttonFlag1 = true;
    }

    public void PushDownE()
    {
        selectUnitNumber = 4;
        buttonFlag1 = true;
        rainShot1 = true;
    }

    public void PushDownF()
    {
        selectUnitNumber = 5;
        buttonFlag1 = true;
    }

    public void PushUpA()
    {
        push_a = false;
        indicater_a[0].SetActive(false);
        indicater_a[1].SetActive(false);
        indicater_a[2].SetActive(false);
    }

    public void PushUpB()
    {
        push_b = false;
        indicater_b[0].SetActive(false);
        indicater_b[1].SetActive(false);
        indicater_b[2].SetActive(false);
    }

    public void PushUpC()
    {
        push_c = false;
        indicater_c[0].SetActive(false);
        indicater_c[1].SetActive(false);
        indicater_c[2].SetActive(false);
    }

    public void PushUpF()
    {

    }

    void Update()
    {
        if (_photonConnecter.canvasFlag == true)
        {
            _indicater0 = GameObject.FindWithTag("indicater0");
            _indicater1 = GameObject.FindWithTag("indicater1");
            _indicater2 = GameObject.FindWithTag("indicater2");
            _indicater3 = GameObject.FindWithTag("indicater3");
            _indicater4 = GameObject.FindWithTag("indicater4");
            _indicater5 = GameObject.FindWithTag("indicater5");
            _indicater6 = GameObject.FindWithTag("indicater6");
            _indicater7 = GameObject.FindWithTag("indicater7");
            _indicater8 = GameObject.FindWithTag("indicater8");

            indicater_a = new GameObject[] { _indicater0, _indicater1, _indicater2 };
            indicater_b = new GameObject[] { _indicater3, _indicater4, _indicater5 };
            indicater_c = new GameObject[] { _indicater6, _indicater7, _indicater8 };

            for (int i = 0; i < indicater_a.Length; i++)
            {
                indicater_a[i].SetActive(false);
                indicater_b[i].SetActive(false);
                indicater_c[i].SetActive(false);
            }
        }
    }

    public void LatePushUpA()
    {
        Invoke("PushUpA", 0.5f);
    }

    public void LatePushUpB()
    {
        Invoke("PushUpB", 0.5f);
    }

    public void LatePushUpC()
    {
        Invoke("PushUpC", 0.5f);
    }

    public void SetUnit(float vecX, float vecY, float vecZ)
    {
        Qii = new Vector3(vecX, vecY, vecZ);
        Qii += UnitSpawn.CastleMain;
        //selectUnitNumber個目のユニットを配置する
        var set = PhotonNetwork.Instantiate(_gameManager.decks[selectUnitNumber].name, Qii, Quaternion.identity);
    }
}
