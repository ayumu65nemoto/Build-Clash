using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�v���C���[��
    const int PLAYER_MAX = 2;
    //���j�b�g�ݒu�X�N���v�g
    private UnitPositionA _unitPositionA;
    private UnitPositionB _unitPositionB;
    private UnitPositionC _unitPositionC;
    //�o�g���J�n�{�^��
    private GameObject _battleStartButton;
    //���j�b�g�z�u�{�^��
    private GameObject _buttonA;
    private GameObject _buttonB;
    private GameObject _buttonC;
    //�퓬�J�n�t���O
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
            //�o�g���X�^�[�g�{�^�������邩�m�F
            //���ꂪ�Ȃ��ƃ{�^�����󂵂�����i���ɃA�N�Z�X�������邽��
            if (_battleStartButton == true)
            {
                _battleStartButton.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        battle = true;
        //SetActive(false)�ł�Update�ɂ���SetActive(true)�ŏ㏑������邽��
        Destroy(_battleStartButton);
    }
}
