using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SelectUnit2 : MonoBehaviourPunCallbacks
{
    //ユニット格納
    [SerializeField] public GameObject[] units2;
    //ユニット番号
    public int selectUnitNumber2;
    //ボタンフラグ
    public bool push_a2 = false;
    public bool push_b2 = false;
    public bool push_c2 = false;
    //矢印格納
    public GameObject[] indicater_a2;
    public GameObject[] indicater_b2;
    public GameObject[] indicater_c2;
    //矢印本体
    public GameObject _indicater02;
    public GameObject _indicater12;
    public GameObject _indicater22;
    public GameObject _indicater32;
    public GameObject _indicater42;
    public GameObject _indicater52;
    public GameObject _indicater62;
    public GameObject _indicater72;
    public GameObject _indicater82;
    //キャンバス確認のためにPhotonConnecterを取得
    private PhotonConnecter _photonConnecter;
    //1Pと2Pを区別するためのフラグ
    public bool buttonFlag2;
    //雨のコマンドをどちらが押したのか
    public bool rainShot2;
    //GameManager
    private GameObject _gameObject;
    private GameManager _gameManager;

    //AR用に追加
    Vector3 Qii;
    GameObject _GM_F;
    CastleSpawn UnitSpawn;
    public bool ARget;
    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber2 = 0;

        //PhotonConnecter取得
        _photonConnecter = GetComponent<PhotonConnecter>();
        //AR用に追加
        UnitSpawn = gameObject.GetComponent<CastleSpawn>();

        buttonFlag2 = false;
        rainShot2 = false;

        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    public void PushDownA()
    {
        push_a2 = true;
        selectUnitNumber2 = 0;
        indicater_a2[0].SetActive(true);
        indicater_a2[1].SetActive(true);
        indicater_a2[2].SetActive(true);
    }

    public void PushDownB()
    {
        push_b2 = true;
        selectUnitNumber2 = 1;
        indicater_b2[0].SetActive(true);
        indicater_b2[1].SetActive(true);
        indicater_b2[2].SetActive(true);
    }

    public void PushDownC()
    {
        push_c2 = true;
        selectUnitNumber2 = 2;
        indicater_c2[0].SetActive(true);
        indicater_c2[1].SetActive(true);
        indicater_c2[2].SetActive(true);
    }

    public void PushDownD()
    {
        selectUnitNumber2 = 3;
        buttonFlag2 = true;
    }

    public void PushDownE()
    {
        selectUnitNumber2 = 4;
        buttonFlag2 = true;
        rainShot2 = true;
    }

    public void PushDownF()
    {
        selectUnitNumber2 = 5;
        buttonFlag2 = true;
    }

    public void PushUpA()
    {
        push_a2 = false;
        indicater_a2[0].SetActive(false);
        indicater_a2[1].SetActive(false);
        indicater_a2[2].SetActive(false);
    }

    public void PushUpB()
    {
        push_b2 = false;
        indicater_b2[0].SetActive(false);
        indicater_b2[1].SetActive(false);
        indicater_b2[2].SetActive(false);
    }

    public void PushUpC()
    {
        push_c2 = false;
        indicater_c2[0].SetActive(false);
        indicater_c2[1].SetActive(false);
        indicater_c2[2].SetActive(false);
    }

    public void PushUpF()
    {

    }

    void Update()
    {
        if (_gameManager.canvasFlag2 == true)
        {
            _indicater02 = GameObject.FindWithTag("id0");
            _indicater12 = GameObject.FindWithTag("id1");
            _indicater22 = GameObject.FindWithTag("id2");
            _indicater32 = GameObject.FindWithTag("id3");
            _indicater42 = GameObject.FindWithTag("id4");
            _indicater52 = GameObject.FindWithTag("id5");
            _indicater62 = GameObject.FindWithTag("id6");
            _indicater72 = GameObject.FindWithTag("id7");
            _indicater82 = GameObject.FindWithTag("id8");

            indicater_a2 = new GameObject[] { _indicater02, _indicater12, _indicater22 };
            indicater_b2 = new GameObject[] { _indicater32, _indicater42, _indicater52 };
            indicater_c2 = new GameObject[] { _indicater62, _indicater72, _indicater82 };

            for (int i = 0; i < indicater_a2.Length; i++)
            {
                indicater_a2[i].SetActive(false);
                indicater_b2[i].SetActive(false);
                indicater_c2[i].SetActive(false);
            }
            _gameManager.canvasFlag2 = false;

        }
        if (ARget == true)
        {
            //AR用に追加
            _GM_F = GameObject.Find("CASTLE");
            UnitSpawn = _GM_F.GetComponent<CastleSpawn>();
            ARget = false;
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
        Qii += _gameManager.posr;
        //selectUnitNumber個目のユニットを配置する
        var set = PhotonNetwork.Instantiate(_gameManager.decks[selectUnitNumber2].name, Qii, Quaternion.identity);
    }
}