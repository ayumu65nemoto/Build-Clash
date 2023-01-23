using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    //���j�b�g�i�[
    [SerializeField] public GameObject[] units;
    //���j�b�g�ԍ�
    public int selectUnitNumber;
    //�{�^���t���O
    public bool push_a = false;
    public bool push_b = false;
    public bool push_c = false;
    //���i�[
    public GameObject[] indicater_a;
    public GameObject[] indicater_b;
    public GameObject[] indicater_c;

    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber = 0;
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

    public void PushDownF()
    {
        selectUnitNumber = 3;
        Debug.Log(selectUnitNumber);
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
        
    }

    public void LatePushUpA()
    {
        Invoke("PushUpA", 1.0f);
    }

    public void LatePushUpB()
    {
        Invoke("PushUpB", 1.0f);
    }

    public void LatePushUpC()
    {
        Invoke("PushUpC", 1.0f);
    }

    public void SetUnit(int vecX, int vecY, int vecZ)
    {
        //selectUnitNumber�ڂ̃��j�b�g��z�u����
        Debug.Log("Set");
        var set = Instantiate(units[selectUnitNumber], new Vector3(vecX, vecY, vecZ), Quaternion.Euler(0f, 0, 0f));
    }
}
