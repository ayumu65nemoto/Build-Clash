using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    //�V���O���g��
    public static GameManager instance;
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
    public GameObject _battleStartButton;
    public GameObject _battleStartButton2;
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
    public bool rain1;
    public bool rain2;
    //�����������Ă��邩
    public bool thunder1;
    public bool thunder2;
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
    private GameObject _textWin2;
    //Lose�e�L�X�g
    private GameObject _textLose;
    private GameObject _textLose2;
    //�L�����o�X�m�F�̂��߂�PhotonConnecter���擾
    private GameObject _photonController;
    private PhotonConnecter _photonConnecter;
    //���̈ʒu�Ƀ��j�b�g���z�u����Ă��邩
    public bool center1;
    public bool right1;
    public bool left1;
    public bool center2;
    public bool right2;
    public bool left2;
    //���_�i�[
    public List<string> myList = new List<string>();
    public List<string> otherList = new List<string>();
    public List<Vector3> PosList = new List<Vector3>();
    public List<Vector3> PosList2 = new List<Vector3>();
    //�X�^�[�g��������x�����s��
    private bool _start;
    //���j�b�g�i�[
    public GameObject[] decks = new GameObject[3];

    //�\������UI
    private GameObject _canvas;
    private GameObject _canvas2;

    //CASTLE�擾
    private CastleSpawn _castleSpawn;
    //castle�o��
    private bool _build1;
    private bool _build2;

    //�L�����o�X�\���t���O
    public bool canvasFlag;
    public bool canvasFlag2;
    //����v���C���[�o���t���O
    public bool p1;
    public bool p2;

    //���X�g�i�[�t���O
    public bool list;

    GameObject _cs;
    CastleSpawn cs_;
    Vector3 poss;
    public Vector3 posr;
    GameObject spawned;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _start = true;
        _build1 = true;
        _build2 = true;
        canvasFlag = false;
        canvasFlag2 = false;
        p1 = false;
        p2 = false;
        list = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BattleAR")
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
            rain1 = false;
            rain2 = false;
            thunder1 = false;
            thunder2 = false;
            isGround1 = false;
            isGround2 = false;

            //���v���C���[�R�A���擾
            _player1 = GameObject.FindWithTag("PlayerCore");
            _player2 = GameObject.FindWithTag("EnemyCore");

            //���s�e�L�X�g�擾
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            _textWin2 = GameObject.FindWithTag("Win2");
            _textLose2 = GameObject.FindWithTag("Lose2");

            //PhotonConnecter�擾
            _photonController = GameObject.Find("PhotonController");
            _photonConnecter = _photonController.GetComponent<PhotonConnecter>();

            //�z�u�m�F�t���O
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
            rain1 = false;
            rain2 = false;
            thunder1 = false;
            thunder2 = false;
            isGround1 = false;
            isGround2 = false;

            //���v���C���[�R�A���擾
            //_player1 = GameObject.FindWithTag("PlayerCore");
            //_player2 = GameObject.FindWithTag("EnemyCore");

            //���s�e�L�X�g�擾
            _textWin = GameObject.FindWithTag("Win");
            _textLose = GameObject.FindWithTag("Lose");
            _textWin2 = GameObject.FindWithTag("Win2");
            _textLose2 = GameObject.FindWithTag("Lose2");

            //PhotonConnecter�擾
            _photonController = GameObject.Find("PhotonController");
            _photonConnecter = _photonController.GetComponent<PhotonConnecter>();
            //_photonConnecter = GetComponent<PhotonConnecter>();

            //�z�u�m�F�t���O
            center1 = false;
            right1 = false;
            left1 = false;
            center2 = false;
            right2 = false;
            left2 = false;

            _canvas = GameObject.FindWithTag("Canvas");
            _canvas2 = GameObject.FindWithTag("Canvas2");
            _canvas.SetActive(false);
            _canvas2.SetActive(false);

            _cs = GameObject.Find("CASTLE");
            cs_ = _cs.GetComponent<CastleSpawn>();
            spawned = GameObject.Find("AR Session Origin");
            //poss = spawned.transform.position;
            _start = false;
        }


        if (SceneManager.GetActiveScene().name == "BattleAR")
        {
            if (_photonConnecter.connect == true)
            {
                if (_photonConnecter.playerId == 1)
                {
                    //var position = new Vector3(0, 1.4f, -10);
                    //var prefab = "PlayerPrefab";
                    _canvas.SetActive(true);
                    canvasFlag = true;
                    p1 = true;
                    //PhotonNetwork.Instantiate(prefab, position, Quaternion.identity);
                    Debug.Log(_photonConnecter.playerId);
                }
                if (_photonConnecter.playerId == 2)
                {
                    poss.z += 8f;
                    spawned.transform.position = poss;
                    spawned.transform.Rotate(0, 180, 0, Space.Self);
                    //var position = new Vector3(0, 1.4f, 6);
                    //var prefab = "EnemyPrefab";
                    _canvas2.SetActive(true);
                    canvasFlag2 = true;
                    p2 = true;
                    //PhotonNetwork.Instantiate(prefab, position, Quaternion.identity);
                    Debug.Log(_photonConnecter.playerId);
                }
                _photonConnecter.connect = false;
            }
            //�L�����o�X����A�N�e�B�u����A�N�e�B�u�ɂȂ����^�C�~���O�ōēx�擾
            //Start���̂��̂͂����Ďc���Ă���(�����ƍŏ��ɌĂ΂ꂽ109�s�ڂŃG���[��f��)
            if (canvasFlag == true)
            {
                //�o�g���X�^�[�g�{�^���擾
                //_battleStartButton = GameObject.FindWithTag("BattleStart");
                //_battleStartButton.SetActive(false);
                _battleStartButton = GameObject.Find("Canvas").transform.Find("BattleStart").gameObject;
                _battleStartButton.SetActive(false);

                //���j�b�g�{�^���擾
                _buttonA = GameObject.Find("ButtonA");
                _buttonB = GameObject.Find("ButtonB");
                _buttonC = GameObject.Find("ButtonC");
                //���j�b�g��ݒu����X�N���v�g���擾
                _unitPositionA = _buttonA.GetComponent<UnitPositionA>();
                _unitPositionB = _buttonB.GetComponent<UnitPositionB>();
                _unitPositionC = _buttonC.GetComponent<UnitPositionC>();

                //���s�e�L�X�g�擾
                _textWin = GameObject.FindWithTag("Win");
                _textLose = GameObject.FindWithTag("Lose");
                //�e�L�X�g��A�N�e�B�u
                _textWin.SetActive(false);
                _textLose.SetActive(false);
                //canvasFlag = false;
            }

            if (canvasFlag2 == true)
            {
                //�o�g���X�^�[�g�{�^���擾
                //_battleStartButton2 = GameObject.FindWithTag("BattleStart2");
                //_battleStartButton2.SetActive(false);
                _battleStartButton2 = GameObject.Find("Canvas2").transform.Find("BattleStart2").gameObject;
                _battleStartButton2.SetActive(false);

                //���j�b�g�{�^���擾
                _buttonA2 = GameObject.Find("ButtonA2");
                _buttonB2 = GameObject.Find("ButtonB2");
                _buttonC2 = GameObject.Find("ButtonC2");
                //���j�b�g��ݒu����X�N���v�g���擾
                _unitPositionA2 = _buttonA2.GetComponent<UnitPositionA2>();
                _unitPositionB2 = _buttonB2.GetComponent<UnitPositionB2>();
                _unitPositionC2 = _buttonC2.GetComponent<UnitPositionC2>();

                //���s�e�L�X�g�擾
                _textWin2 = GameObject.FindWithTag("Win2");
                _textLose2 = GameObject.FindWithTag("Lose2");
                //�e�L�X�g��A�N�e�B�u
                _textWin2.SetActive(false);
                _textLose2.SetActive(false);
                //canvasFlag2 = false;
            }

            if (_unitPositionA.setUnitA == true && _unitPositionB.setUnitB == true && _unitPositionC.setUnitC == true)
            {
                //�o�g���X�^�[�g�{�^�������邩�m�F
                //���ꂪ�Ȃ��ƃ{�^�����󂵂�����i���ɃA�N�Z�X�������邽��
                _battleStartButton = GameObject.Find("Canvas").transform.Find("BattleStart").gameObject;
                _battleStartButton.SetActive(false);
                if (_battleStartButton == true)
                {
                    _battleStartButton.SetActive(true);
                }
                _unitPositionA.setUnitA = false;
            }

            if (_unitPositionA2.setUnitA2 == true && _unitPositionB2.setUnitB2 == true && _unitPositionC2.setUnitC2 == true)
            {
                //�o�g���X�^�[�g�{�^�������邩�m�F
                //���ꂪ�Ȃ��ƃ{�^�����󂵂�����i���ɃA�N�Z�X�������邽��
                _battleStartButton2 = GameObject.Find("Canvas2").transform.Find("BattleStart2").gameObject;
                _battleStartButton2.SetActive(false);
                if (_battleStartButton2 == true)
                {
                    _battleStartButton2.SetActive(true);
                }
                _unitPositionA2.setUnitA2 = false;
            }

            if (battle1 == true && battle2 == true)
            {
                battle = true;
            }

            if (isGround1 == true)
            {
                _textLose = GameObject.Find("Canvas").transform.Find("Lose").gameObject;
                _textLose.SetActive(true);
                _textWin2 = GameObject.Find("Canvas2").transform.Find("Win").gameObject;
                _textWin2.SetActive(true);
                Destroy(_textWin);
                Destroy(_textLose2);
                Invoke("Finish", 3f);
            }

            if (isGround2 == true)
            {
                _textWin = GameObject.Find("Canvas").transform.Find("Win").gameObject;
                _textWin.SetActive(true);
                _textLose2 = GameObject.Find("Canvas2").transform.Find("Lose").gameObject;
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

            if (_build1 == true &&  _photonConnecter.playerId == 1)
            {
                //CastleCreate();
                PhotonNetwork.Instantiate("PlayerPrefab", new Vector3(0, 1.5f, -7), Quaternion.identity);
                _build1 = false;
            }

            if (_build2 == true && _photonConnecter.playerId == 2)
            {
                //CastleCreate2();
                PhotonNetwork.Instantiate("EnemyPrefab", new Vector3(0, 1.5f, 5), Quaternion.identity);
                _build2 = false;
            }

        }
    }

    public void OnClick()
    {
        //battle = true;
        battle1 = true;
        //SetActive(false)�ł�Update�ɂ���SetActive(true)�ŏ㏑������邽��
        Destroy(_battleStartButton);
    }

    public void OnClick2()
    {
        //battle = true;
        battle2 = true;
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
        _castleSpawn = GameObject.Find("CASTLE").GetComponent<CastleSpawn>();
        posr = _castleSpawn.CastleMain;
        for (int i = 0; i < PosList.Count; i++)
        {
            Vector3 sss = PosList[i];
            sss += _castleSpawn.CastleMain;
            sss.x = sss.x * 1;
            sss.z = sss.z * 1;
            sss.y += 0.1f;
            string prefab = myList[i].Replace("(Clone)", "");
            GameObject unit = PhotonNetwork.Instantiate(prefab, sss, Quaternion.identity);
            Destroy(unit.GetComponent<Rigidbody>());
            unit.tag = "Player";
            unit.AddComponent<PlayerStates>();
            unit.AddComponent<Player>();
            if (unit.name == "KINGBLOCK")
            {
                unit.tag = "PlayerCore";
                unit.AddComponent<PlayerCore>();
            }
        }
    }

    void CastleCreate2()
    {
        _castleSpawn = GameObject.Find("CASTLE").GetComponent<CastleSpawn>();
        for (int i = 0; i < PosList.Count; i++)
        {
            Vector3 sss = PosList[i];
            sss += posr;
            sss.x = sss.x * -1;
            sss.z = sss.z * -1;
            sss.y += 0.1f;
            sss.z += 6f;
            string prefab = myList[i].Replace("(Clone)", "");
            GameObject unit = PhotonNetwork.Instantiate(prefab, sss, Quaternion.identity);
            Destroy(unit.GetComponent<Rigidbody>());
            unit.tag = "Enemy";
            unit.AddComponent<PlayerStates2>();
            unit.AddComponent<Player>();
            if (unit.name == "KINGBLOCK")
            {
                unit.tag = "EnemyCore";
                unit.AddComponent<EnemyCore>();
            }
        }
    }

    void Finish()
    {
        SceneManager.LoadScene("Home");
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //�f�[�^�̑��M
            stream.SendNext(battle1);
            stream.SendNext(battle2);
            stream.SendNext(posr);
        }
        else
        {
            //�f�[�^�̎�M
            battle1 = (bool)stream.ReceiveNext();
            battle2 = (bool)stream.ReceiveNext();
            posr = (Vector3)stream.ReceiveNext();
        }
    }
}
