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
    //バトル開始ボタン
    private GameObject _battleStartButton;
    //ユニット配置ボタン
    private GameObject _buttonA;
    private GameObject _buttonB;
    private GameObject _buttonC;
    //戦闘開始フラグ
    public bool battle;
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

    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        if (_unitPositionA.setUnitA == true && _unitPositionB.setUnitB == true && _unitPositionC.setUnitC && true)
        {
            //バトルスタートボタンがあるか確認
            //これがないとボタンを壊した後も永遠にアクセスし続けるため
            if (_battleStartButton == true)
            {
                _battleStartButton.SetActive(true);
            }
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
        battle = true;
        //SetActive(false)ではUpdateにあるSetActive(true)で上書きされるため
        Destroy(_battleStartButton);
    }
}
