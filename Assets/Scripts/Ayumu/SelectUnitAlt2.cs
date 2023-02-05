using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitAlt2 : MonoBehaviour
{
    private GameObject _gameObject;
    private GameManager _gameManager;
    private SelectUnit2 _selectUnit2;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
        _selectUnit2 = GameObject.Find("Canvas2").GetComponent<SelectUnit2>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushDownA()
    {
        _selectUnit2.push_a2 = true;
        _selectUnit2.selectUnitNumber2 = 0;
    }

    public void PushDownB()
    {
        _selectUnit2.push_b2 = true;
        _selectUnit2.selectUnitNumber2 = 1;
    }

    public void PushDownC()
    {
        _selectUnit2.push_c2 = true;
        _selectUnit2.selectUnitNumber2 = 2;
    }

    public void PushDownD()
    {
        _selectUnit2.selectUnitNumber2 = 3;
        //buttonFlag1 = true;
    }

    public void PushDownE()
    {
        _selectUnit2.selectUnitNumber2 = 4;
        //buttonFlag1 = true;
        //rainShot1 = true;
    }

    public void PushDownF()
    {
        _selectUnit2.selectUnitNumber2 = 5;
        //buttonFlag1 = true;
    }

    public void PushUpA()
    {
        _selectUnit2.push_a2 = false;
    }

    public void PushUpB()
    {
        _selectUnit2.push_b2 = false;
    }

    public void PushUpC()
    {
        _selectUnit2.push_c2 = false;
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

    public void OnClick2()
    {
        _gameManager.battle = true;
        //battle1 = true;
        //SetActive(false)Ç≈ÇÕUpdateÇ…Ç†ÇÈSetActive(true)Ç≈è„èëÇ´Ç≥ÇÍÇÈÇΩÇﬂ
        Destroy(GameObject.FindWithTag("BattleStart2"));
    }
}
