using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBase : MonoBehaviour
{
    //拠点格納
    public GameObject[] bases;
    //拠点番号
    public int setBaseNumber;
    //拠点設置フラグ
    public bool baseFlag;

    // Start is called before the first frame update
    void Start()
    {
        setBaseNumber = 0;
        baseFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (baseFlag == true)
        {
            if (setBaseNumber == 0)
            {
                SetBases(0, 1.5f, -4);
                setBaseNumber += 1;
                Debug.Log("1");
            }

            if (setBaseNumber == 1)
            {
                SetBases(0, 1.5f, 0);
                baseFlag = false;
                Debug.Log("2");
            }
        }
    }

    public void SetBases(float vecX, float vecY, float vecZ)
    {
        //selectUnitNumber個目のユニットを配置する
        var set = Instantiate(bases[setBaseNumber], new Vector3(vecX, vecY, vecZ), Quaternion.identity);
    }
}
