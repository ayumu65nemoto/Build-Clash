using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    //シングルトン
    public static GameManager instance;
    //プレイヤー数
    const int PLAYER_MAX = 2;
    //ユニット設置スクリプト
    private UnitPositionA _unitPositionA;
    private UnitPositionB _unitPositionB;
    private UnitPositionC _unitPositionC;
    private UnitPositionA2 _unitPositionA2;
    private UnitPositionB2 _unitPositionB2;
    private UnitPositionC2 _unitPositionC2;
    //バトル開始ボタン
    private GameObject _battleStartButton;
    private GameObject _battleStartButton2;
    //ユニット配置ボタン
    private GameObject _buttonA;
    private GameObject _buttonB;
    private GameObject _buttonC;
    private GameObject _buttonA2;
    private GameObject _buttonB2;
    private GameObject _buttonC2;
    //戦闘開始フラグ
    public bool battle;
    public bool battle1;
    public bool battle2;
    //雨が降っているか
    public bool rain1;
    public bool rain2;
    //雷が発動しているか
    public bool thunder1;
    public bool thunder2;
    //プレイヤー１
    private GameObject _player1;
    //接地判定
    public bool isGround1;
    //プレイヤー２
    private GameObject _player2;
    //接地判定
    public bool isGround2;
    //Winテキスト
    private GameObject _textWin;
    private GameObject _textWin2;
    //Loseテキスト
    private GameObject _textLose;
    private GameObject _textLose2;
    //キャンバス確認のためにPhotonConnecterを取得
    private PhotonConnecter _photonConnecter;
    //その位置にユニットが配置されているか
    public bool center1;
    public bool right1;
    public bool left1;
    public bool center2;
    public bool right2;
    public bool left2;
    //拠点格納
    public List<GameObject> myList = new List<GameObject>();
    //スタート処理を一度だけ行う
    private bool _start;

    public List<Vector3> PosList = new List<Vector3>();
    //ユニット格納
    public GameObject[] decks = new GameObject[3];

    //表示するUI
    private GameObject _canvas;
    private GameObject _canvas2;

    //CASTLE取得
    private CastleSpawn _castleSpawn;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _start = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BattleAR")
        {
            //バトルスタートボタン取得
            _battleStartButton = GameObject.FindWithTag("BattleStart");
            //_battleStartButton.SetActive(false);  //なぜここをfalseにしていた！と自分をぶん殴りたい
            _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
            //_battleStartButton2.SetActive(false);

            //ユニットボタン取得
            _buttonA = GameObject.Find("ButtonA");
            _buttonB = GameObject.Find("ButtonB");
            _buttonC = GameObject.Find("ButtonC");
            _buttonA2 = GameObject.Find("ButtonA2");
            _buttonB2 = GameObject.Find("ButtonB2");
            _buttonC2 = GameObject.Find("ButtonC2");
            //ユニットを設置するスクリプトを取得
            _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
            _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
            _unitPositionC = _buttonC.GetComponent<UnitPositionC>();
            _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
            _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
            _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

            //各種フラグ
            battle = false;
            rain1 = false;
            rain2 = false;
            thunder1 = false;
            thunder2 = false;
            isGround1 = false;
            isGround2 = false;

            //両プレイヤーコアを取得
            _player1 = GameObject.FindWithTag("PlayerCore");
            _player2 = GameObject.FindWithTag("EnemyCore");

            //勝敗テキスト取得
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            _textWin2 = GameObject.FindWithTag("Win2");
            _textLose2 = GameObject.FindWithTag("Lose2");

            //PhotonConnecter取得
            _photonConnecter = GetComponent<PhotonConnecter>();

            //配置確認フラグ
            center1 = false;
            right1 = false;
            left1 = false;
            center2 = false;
            right2 = false;
            left2 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "BattleAR" && _start == true)
        {
            //バトルスタートボタン取得
            _battleStartButton = GameObject.FindWithTag("BattleStart");
            //_battleStartButton.SetActive(false);  //なぜここをfalseにしていた！と自分をぶん殴りたい
            _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
            //_battleStartButton2.SetActive(false);

            //ユニットボタン取得
            _buttonA = GameObject.Find("ButtonA");
            _buttonB = GameObject.Find("ButtonB");
            _buttonC = GameObject.Find("ButtonC");
            _buttonA2 = GameObject.Find("ButtonA2");
            _buttonB2 = GameObject.Find("ButtonB2");
            _buttonC2 = GameObject.Find("ButtonC2");
            //ユニットを設置するスクリプトを取得
            _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
            _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
            _unitPositionC = _buttonC.GetComponent<UnitPositionC>();
            _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
            _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
            _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

            //各種フラグ
            battle = false;
            rain1 = false;
            rain2 = false;
            thunder1 = false;
            thunder2 = false;
            isGround1 = false;
            isGround2 = false;

            //両プレイヤーコアを取得
            _player1 = GameObject.FindWithTag("PlayerCore");
            _player2 = GameObject.FindWithTag("EnemyCore");

            //勝敗テキスト取得
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            _textWin2 = GameObject.FindWithTag("Win2");
            _textLose2 = GameObject.FindWithTag("Lose2");

            //PhotonConnecter取得
            _photonConnecter = GetComponent<PhotonConnecter>();

            //配置確認フラグ
            center1 = false;
            right1 = false;
            left1 = false;
            center2 = false;
            right2 = false;
            left2 = false;

            _start = false;
            _canvas = GameObject.FindWithTag("Canvas");
            _canvas2 = GameObject.FindWithTag("Canvas2");
            _canvas.SetActive(false);
            _canvas2.SetActive(false);

            if (_photonConnecter.playerId == 1)
            {
                //var position = new Vector3(0, 1.4f, -10);
                //var prefab = "PlayerPrefab";
                _canvas.SetActive(true);
                _photonConnecter.canvasFlag = true;
                _photonConnecter.p1 = true;
                //PhotonNetwork.Instantiate(prefab, position, Quaternion.identity);
                Debug.Log(_photonConnecter.playerId);
            }
            if (_photonConnecter.playerId == 2)
            {
                //var position = new Vector3(0, 1.4f, 6);
                //var prefab = "EnemyPrefab";
                _canvas2.SetActive(true);
                _photonConnecter.canvasFlag2 = true;
                _photonConnecter.p2 = true;
                //PhotonNetwork.Instantiate(prefab, position, Quaternion.identity);
                Debug.Log(_photonConnecter.playerId);
            }

            Invoke("CastleCreate", 1f);
        }

        if (SceneManager.GetActiveScene().name == "BattleAR")
        {
            //キャンバスが非アクティブからアクティブになったタイミングで再度取得
            //Start内のものはあえて残している(無いと最初に呼ばれた109行目でエラーを吐く)
            if (_photonConnecter.canvasFlag == true)
            {
                //バトルスタートボタン取得
                _battleStartButton = GameObject.FindWithTag("BattleStart");
                _battleStartButton.SetActive(false);

                //ユニットボタン取得
                _buttonA = GameObject.Find("ButtonA");
                _buttonB = GameObject.Find("ButtonB");
                _buttonC = GameObject.Find("ButtonC");
                //ユニットを設置するスクリプトを取得
                _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
                _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
                _unitPositionC = _buttonC.GetComponent<UnitPositionC>();

                //勝敗テキスト取得
                _textWin = GameObject.FindWithTag("Win");
                _textLose = GameObject.FindWithTag("Lose");
                //テキスト非アクティブ
                _textWin.SetActive(false);
                _textLose.SetActive(false);

                //_photonConnecter.canvasFlag = false;
            }

            if (_photonConnecter.canvasFlag2 == true)
            {
                //バトルスタートボタン取得
                _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
                _battleStartButton2.SetActive(false);

                //ユニットボタン取得
                _buttonA2 = GameObject.Find("ButtonA2");
                _buttonB2 = GameObject.Find("ButtonB2");
                _buttonC2 = GameObject.Find("ButtonC2");
                //ユニットを設置するスクリプトを取得
                _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
                _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
                _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

                //勝敗テキスト取得
                _textWin2 = GameObject.FindWithTag("Win2");
                _textLose2 = GameObject.FindWithTag("Lose2");
                //テキスト非アクティブ
                _textWin2.SetActive(false);
                _textLose2.SetActive(false);
            }

            if (_unitPositionA.setUnitA == true && _unitPositionB.setUnitB == true && _unitPositionC.setUnitC && true)
            {
                //バトルスタートボタンがあるか確認
                //これがないとボタンを壊した後も永遠にアクセスし続けるため
                if (_battleStartButton == true)
                {
                    _battleStartButton.SetActive(true);
                }
            }

            if (_unitPositionA2.setUnitA2 == true && _unitPositionB2.setUnitB2 == true && _unitPositionC2.setUnitC2 && true)
            {
                //バトルスタートボタンがあるか確認
                //これがないとボタンを壊した後も永遠にアクセスし続けるため
                if (_battleStartButton2 == true)
                {
                    _battleStartButton2.SetActive(true);
                }
            }

            if (battle1 == true && battle2 == true)
            {
                battle = true;
            }

            if (isGround1 == true)
            {
                _textLose.SetActive(true);
                _textWin2.SetActive(true);
                Destroy(_textWin);
                Destroy(_textLose2);
                Invoke("Finish", 3f);
            }

            if (isGround2 == true)
            {
                _textWin.SetActive(true);
                _textLose2.SetActive(true);
                Destroy(_textLose);
                Destroy(_textWin2);
                Invoke("Finish", 3f);
            }

            if (thunder1 == true)
            {
                photonView.RPC("ThunderDestroy1", RpcTarget.All);
                thunder1 = false;
            }

            if (thunder2 == true)
            {
                photonView.RPC("ThunderDestroy2", RpcTarget.All);
                thunder2 = false;
            }
        }
    }

    public void OnClick()
    {
        battle = true;
        //battle1 = true;
        //SetActive(false)ではUpdateにあるSetActive(true)で上書きされるため
        Destroy(_battleStartButton);
    }

    public void OnClick2()
    {
        battle = true;
        //battle2 = true;
        Destroy(_battleStartButton2);
    }

    [PunRPC]
    void ThunderDestroy1()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < 5; i++)
        {
            GameObject block = blocks[i];
            Debug.Log(block);
            Destroy(block);
        }
    }

    [PunRPC]
    void ThunderDestroy2()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < 5; i++)
        {
            GameObject block = blocks[i];
            Debug.Log(block);
            Destroy(block);
        }
    }

    void CastleCreate()
    {
        _castleSpawn = GetComponent<CastleSpawn>();
        for (int i = 0; i < myList.Count; i++)
        {
            Vector3 sss = PosList[i];
            sss += _castleSpawn.CastleMain;
            sss.x = sss.x * 1;
            sss.z = sss.z * 1;
            sss.y += 0.1f;


            PhotonNetwork.Instantiate(myList[i].name, sss, Quaternion.identity);
        }
    }

    void Finish()
    {
        SceneManager.LoadScene("Home");
    }
}
