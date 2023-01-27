using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�v���C���[��
    const int PLAYER_MAX = 2;
    //���j�b�g�ݒu�X�N���v�g
    private UnitPositionA _unitPositionA;
    private UnitPositionB _unitPositionB;
    private UnitPositionC _unitPositionC;
    private UnitPositionA2 _unitPositionA2;
    private UnitPositionB2 _unitPositionB2;
    private UnitPositionC2 _unitPositionC2;
    //�o�g���J�n�{�^��
    private GameObject _battleStartButton;
    private GameObject _battleStartButton2;
    //���j�b�g�z�u�{�^��
    private GameObject _buttonA;
    private GameObject _buttonB;
    private GameObject _buttonC;
    private GameObject _buttonA2;
    private GameObject _buttonB2;
    private GameObject _buttonC2;
    //�퓬�J�n�t���O
    public bool battle;
    public bool battle1;
    public bool battle2;
    //�J���~���Ă��邩
    public bool rain;
    //�����������Ă��邩
    public bool thunder;
    //�v���C���[�P
    private GameObject _player1;
    //�ڒn����
    public bool isGround1;
    //�v���C���[�Q
    private GameObject _player2;
    //�ڒn����
    public bool isGround2;
    //Win�e�L�X�g
    private GameObject _textWin;
    //Lose�e�L�X�g
    private GameObject _textLose;
    //�L�����o�X�m�F�̂��߂�PhotonConnecter���擾
    private PhotonConnecter _photonConnecter;

    // Start is called before the first frame update
    void Start()
    {
        //�o�g���X�^�[�g�{�^���擾
        _battleStartButton = GameObject.FindWithTag("BattleStart");
        //_battleStartButton.SetActive(false);  //�Ȃ�������false�ɂ��Ă����I�Ǝ������Ԃ񉣂肽��
        _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
        //_battleStartButton2.SetActive(false);

        //���j�b�g�{�^���擾
        _buttonA = GameObject.Find("ButtonA");
        _buttonB = GameObject.Find("ButtonB");
        _buttonC = GameObject.Find("ButtonC");
        _buttonA2 = GameObject.Find("ButtonA2");
        _buttonB2 = GameObject.Find("ButtonB2");
        _buttonC2 = GameObject.Find("ButtonC2");
        //���j�b�g��ݒu����X�N���v�g���擾
        _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
        _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
        _unitPositionC = _buttonC.GetComponent<UnitPositionC>();
        _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
        _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
        _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

        //�e��t���O
        battle = false;
        rain = false;
        thunder = false;
        isGround1 = false;
        isGround2 = false;

        //���v���C���[�R�A���擾
        _player1 = GameObject.FindWithTag("PlayerCore");
        _player2 = GameObject.FindWithTag("EnemyCore");
        
        //���s�e�L�X�g�擾
        _textWin = GameObject.FindWithTag("Win");
        _textLose = GameObject.FindWithTag("Lose");
        //�e�L�X�g��A�N�e�B�u
        //_textWin.SetActive(false);
        //_textLose.SetActive(false);

        //PhotonConnecter�擾
        _photonConnecter = GetComponent<PhotonConnecter>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����o�X����A�N�e�B�u����A�N�e�B�u�ɂȂ����^�C�~���O�ōēx�擾
        //Start���̂��̂͂����Ďc���Ă���(�����ƍŏ��ɌĂ΂ꂽ109�s�ڂŃG���[��f��)
        if (_photonConnecter.canvasFlag == true)
        {
            //�o�g���X�^�[�g�{�^���擾
            _battleStartButton = GameObject.FindWithTag("BattleStart");
            _battleStartButton.SetActive(false);
            //_battleStartButton2 = GameObject.FindWithTag("BattleStart2");
            //_battleStartButton2.SetActive(false);

            //���j�b�g�{�^���擾
            _buttonA = GameObject.Find("ButtonA");
            _buttonB = GameObject.Find("ButtonB");
            _buttonC = GameObject.Find("ButtonC");
            //_buttonA2 = GameObject.Find("ButtonA2");
            //_buttonB2 = GameObject.Find("ButtonB2");
            //_buttonC2 = GameObject.Find("ButtonC2");
            //���j�b�g��ݒu����X�N���v�g���擾
            _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
            _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
            _unitPositionC = _buttonC.GetComponent<UnitPositionC>();
            //_unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
            //_unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
            //_unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

            //���s�e�L�X�g�擾
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            //�e�L�X�g��A�N�e�B�u
            _textWin.SetActive(false);
            _textLose.SetActive(false);

            _photonConnecter.canvasFlag = false;
        }

        if (_photonConnecter.canvasFlag2 == true)
        {
            //�o�g���X�^�[�g�{�^���擾
            //_battleStartButton = GameObject.FindWithTag("BattleStart");
            //_battleStartButton.SetActive(false);
            _battleStartButton2 = GameObject.FindWithTag("BattleStart2");
            _battleStartButton2.SetActive(false);

            //���j�b�g�{�^���擾
            //_buttonA = GameObject.Find("ButtonA");
            //_buttonB = GameObject.Find("ButtonB");
            //_buttonC = GameObject.Find("ButtonC");
            _buttonA2 = GameObject.Find("ButtonA2");
            _buttonB2 = GameObject.Find("ButtonB2");
            _buttonC2 = GameObject.Find("ButtonC2");
            //���j�b�g��ݒu����X�N���v�g���擾
            //_unitPositionA = _buttonA.GetComponent<UnitPositionA>();
            //_unitPositionB = _buttonB.GetComponent<UnitPositionB>();
            //_unitPositionC = _buttonC.GetComponent<UnitPositionC>();
            _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
            _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
            _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

            //���s�e�L�X�g�擾
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            //�e�L�X�g��A�N�e�B�u
            _textWin.SetActive(false);
            _textLose.SetActive(false);

            //_photonConnecter.canvasFlag = false;
        }

        if (_unitPositionA.setUnitA == true && _unitPositionB.setUnitB == true && _unitPositionC.setUnitC && true)
        {
            //�o�g���X�^�[�g�{�^�������邩�m�F
            //���ꂪ�Ȃ��ƃ{�^�����󂵂�����i���ɃA�N�Z�X�������邽��
            if (_battleStartButton == true)
            {
                _battleStartButton.SetActive(true);
            }
        }

        if (_unitPositionA2.setUnitA2 == true && _unitPositionB2.setUnitB2 == true && _unitPositionC2.setUnitC2 && true)
        {
            //�o�g���X�^�[�g�{�^�������邩�m�F
            //���ꂪ�Ȃ��ƃ{�^�����󂵂�����i���ɃA�N�Z�X�������邽��
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
        battle = true;
        //battle1 = true;
        //SetActive(false)�ł�Update�ɂ���SetActive(true)�ŏ㏑������邽��
        Destroy(_battleStartButton);
    }

    public void OnClick2()
    {
        battle = true;
        //battle2 = true;
        Destroy(_battleStartButton2);
    }
}
