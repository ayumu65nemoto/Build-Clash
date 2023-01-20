using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        _battleStartButton = GameObject.FindWithTag("BattleStart");
        _buttonA = GameObject.Find("ButtonA");
        _buttonB = GameObject.Find("ButtonB");
        _buttonC = GameObject.Find("ButtonC");
        _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
        _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
        _unitPositionC = _buttonC.GetComponent<UnitPositionC>();
        _battleStartButton.SetActive(false);
        battle = false;
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
    }

    public void OnClick()
    {
        battle = true;
        //SetActive(false)ではUpdateにあるSetActive(true)で上書きされるため
        Destroy(_battleStartButton);
    }
}
