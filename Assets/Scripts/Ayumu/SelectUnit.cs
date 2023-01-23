using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    //���j�b�g�i�[
    [SerializeField] GameObject[] units;
    //���j�b�g�ԍ�
    public int selectUnitNumber;
    private int vecX = 0;
    private int vecY = 1;
    private int vecZ = -5;

    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber = 0;
    }

    public void OnClickA()
    {
        selectUnitNumber = 0;
        SetUnit();
    }

    public void OnClickB()
    {
        selectUnitNumber = 1;
        SetUnit();
    }

    public void OnClickC()
    {
        selectUnitNumber = 2;
        SetUnit();
    }

    public void SetUnit()
    {
        //selectUnitNumber�ڂ̃��j�b�g��z�u����
        var unit = Instantiate(units[selectUnitNumber], new Vector3(vecX, vecY, vecZ), Quaternion.Euler(0f, 0, 0f));
    }
}
