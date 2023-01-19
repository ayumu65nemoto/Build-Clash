using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    //ユニット格納
    [SerializeField] GameObject[] units;
    public GameObject unit;
    //ユニット番号
    public int selectUnitNumber;
    //ボタンフラグ
    public bool push_a = false;
    public bool push_b = false;
    public bool push_c = false;

    // Start is called before the first frame update
    void Start()
    {
        selectUnitNumber = 0;
    }

    public void PushDownA()
    {
        push_a = true;
    }

    public void PushDownB()
    {
        push_b = true;
    }

    public void PushDownC()
    {
        push_c = true;
    }

    public void PushUpA()
    {
        push_a = false;
    }

    public void PushUpB()
    {
        push_b = false;
    }

    public void PushUpC()
    {
        push_c = false;
    }

    void Update()
    {
        if (push_a == true)
        {
            selectUnitNumber = 0;
            PresetUnit();
        }
        if (push_b == true)
        {
            selectUnitNumber = 1;
            PresetUnit();
        }
        if (push_c == true)
        {
            selectUnitNumber = 2;
            PresetUnit();
        }
    }

    public void PresetUnit()
    {
        unit = units[selectUnitNumber];
    }

    public void SetUnit(int vecX, int vecY, int vecZ)
    {
        //selectUnitNumber個目のユニットを配置する
        var set = Instantiate(unit, new Vector3(vecX, vecY, vecZ), Quaternion.Euler(0f, 0, 0f));
    }
}
