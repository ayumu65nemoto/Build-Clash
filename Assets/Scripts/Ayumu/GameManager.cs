using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    private bool battle1;
    private bool battle2;
    //雨が降っているか
    public bool rain;
    //雷が発動しているか
    public bool thunder;
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
    //Loseテキスト
    private GameObject _textLose;
    //キャンバス確認のためにPhotonConnecterを取得
    private PhotonConnecter _photonConnecter;

    // Start is called before the first frame update
    void Start()
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
        rain = false;
        thunder = false;
        isGround1 = false;
        isGround2 = false;

        //両プレイヤーコアを取得
        _player1 = GameObject.FindWithTag("PlayerCore");
        _player2 = GameObject.FindWithTag("EnemyCore");
        
        //勝敗テキスト取得
        _textWin = GameObject.FindWithTag("Win");
        _textLose = GameObject.FindWithTag("Lose");
        //テキスト非アクティブ
        _textWin.SetActive(false);
        _textLose.SetActive(false);

        //PhotonConnecter取得
        _photonConnecter = GetComponent<PhotonConnecter>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャンバスが非アクティブからアクティブになったタイミングで再度取得
        //Start内のものはあえて残している(無いと最初に呼ばれた109行目でエラーを吐く)
        if (_photonConnecter.canvasFlag == true)
        {
            //バトルスタートボタン取得
            _battleStartButton = GameObject.FindWithTag("BattleStart");
            _battleStartButton.SetActive(false);
            _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
            _battleStartButton2.SetActive(false);

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

            //勝敗テキスト取得
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            //テキスト非アクティブ
            _textWin.SetActive(false);
            _textLose.SetActive(false);

            _photonConnecter.canvasFlag = false;
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
        }

        if (isGround2 == true)
        {
            _textWin.SetActive(true);
        }
    }

    public void OnClick()
    {
        //battle = true;
        battle1 = true;
        //SetActive(false)ではUpdateにあるSetActive(true)で上書きされるため
        Destroy(_battleStartButton);
    }

    public void OnClick2()
    {
        battle2 = true;
        Destroy(_battleStartButton2);
    }
}
