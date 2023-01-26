using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SelectUnit2 : MonoBehaviour
{
    //���j�b�g�i�[
    [SerializeField] public GameObject[] units2;
    //���j�b�g�ԍ�
    public int selectUnitNumber2;
    //�{�^���t���O
    public bool push_a2 = false;
    public bool push_b2 = false;
    public bool push_c2 = false;
    //���i�[
    public GameObject[] indicater_a2;
    public GameObject[] indicater_b2;
    public GameObject[] indicater_c2;
    //���{��
    public GameObject _indicater02;
    public GameObject _indicater12;
    public GameObject _indicater22;
    public GameObject _indicater32;
    public GameObject _indicater42;
    public GameObject _indicater52;
    public GameObject _indicater62;
    public GameObject _indicater72;
    public GameObject _indicater82;
    //�L�����o�X�m�F�̂��߂�PhotonConnecter���擾
    private PhotonConnecter _photonConnecter;

    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber2 = 0;

        //PhotonConnecter�擾
        _photonConnecter = GetComponent<PhotonConnecter>();
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
    }

    public void PushDownE()
    {
        selectUnitNumber2 = 4;
    }

    public void PushDownF()
    {
        selectUnitNumber2 = 5;
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
        if (_photonConnecter.canvasFlag == true)
        {
            _indicater02 = GameObject.FindWithTag("indicater0");
            _indicater12 = GameObject.FindWithTag("indicater1");
            _indicater22 = GameObject.FindWithTag("indicater2");
            _indicater32 = GameObject.FindWithTag("indicater3");
            _indicater42 = GameObject.FindWithTag("indicater4");
            _indicater52 = GameObject.FindWithTag("indicater5");
            _indicater62 = GameObject.FindWithTag("indicater6");
            _indicater72 = GameObject.FindWithTag("indicater7");
            _indicater82 = GameObject.FindWithTag("indicater8");

            indicater_a2 = new GameObject[] { _indicater02, _indicater12, _indicater22 };
            indicater_b2 = new GameObject[] { _indicater32, _indicater42, _indicater52 };
            indicater_c2 = new GameObject[] { _indicater62, _indicater72, _indicater82 };

            for (int i = 0; i < indicater_a2.Length; i++)
            {
                indicater_a2[i].SetActive(false);
                indicater_b2[i].SetActive(false);
                indicater_c2[i].SetActive(false);
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
        //selectUnitNumber�ڂ̃��j�b�g��z�u����
        var set = PhotonNetwork.Instantiate(units2[selectUnitNumber2].name, new Vector3(vecX, vecY, vecZ), Quaternion.identity);
    }
}