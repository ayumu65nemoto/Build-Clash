using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitAlt : MonoBehaviour
{
    private GameObject _gameObject;
    private GameManager _gameManager;
    private SelectUnit _selectUnit;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _selectUnit = _gameObject.GetComponent<SelectUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushDownA()
    {
        _selectUnit.push_a = true;
        _selectUnit.selectUnitNumber = 0;
    }

    public void PushDownB()
    {
        _selectUnit.push_b = true;
        _selectUnit.selectUnitNumber = 1;
    }

    public void PushDownC()
    {
        _selectUnit.push_c = true;
        _selectUnit.selectUnitNumber = 2;
    }

    public void PushDownD()
    {
        _selectUnit.selectUnitNumber = 3;
        //buttonFlag1 = true;
    }

    public void PushDownE()
    {
        _selectUnit.selectUnitNumber = 4;
        //buttonFlag1 = true;
        //rainShot1 = true;
    }

    public void PushDownF()
    {
        _selectUnit.selectUnitNumber = 5;
        //buttonFlag1 = true;
    }

    public void PushUpA()
    {
        _selectUnit.push_a = false;
    }

    public void PushUpB()
    {
        _selectUnit.push_b = false;
    }

    public void PushUpC()
    {
        _selectUnit.push_c = false;
    }

    public void PushUpF()
    {

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

    public void OnClick()
    {
        _gameManager.battle = true;
        //battle1 = true;
        //SetActive(false)Ç≈ÇÕUpdateÇ…Ç†ÇÈSetActive(true)Ç≈è„èëÇ´Ç≥ÇÍÇÈÇΩÇﬂ
        Destroy(GameObject.FindWithTag("BattleStart"));
    }
}
