using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPositionC : MonoBehaviour
{
    public enum FlickDirection
    {
        Left,
        Right,
        Up,
    }

    Vector3 _clickStartPosition = Vector2.zero;
    //閾値
    [SerializeField] float _threshold = 30;
    private GameObject _gameObject;
    private SelectUnit _selectUnit;
    private GameManager _gameManager;
    //ユニット配置完了フラグ
    public bool setUnitC;
    //ユニット配置回数
    private int _unit;

    // Start is called before the first frame update
    void Start()
    {
        setUnitC = false;
        _unit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タップした点を取得
            _clickStartPosition = Input.mousePosition;

            _gameObject = GameObject.FindWithTag("GameManager");
            _selectUnit = _gameObject.GetComponent<SelectUnit>();
            _gameManager = _gameObject.GetComponent<GameManager>();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //離した点を取得して、タップした点との距離を測る
            Vector3 dif = Input.mousePosition - _clickStartPosition;

            //負の値を取る子ともあるのでAbsで絶対値に
            float abs_x = Mathf.Abs(dif.x);
            float abs_y = Mathf.Abs(dif.y);

            //閾値(反応する最小値)
            if (abs_x >= _threshold || abs_y >= _threshold)
            {
                if (_selectUnit.push_c == true)
                {
                    // 横方向
                    if (abs_x > abs_y)
                    {
                        //Flick(dif.x > 0 ? FlickDirection.Right : FlickDirection.Left);
                        if (dif.x > 0)
                        {
                            if (_gameManager.right1 != true && _unit > 0)
                            {
                                Flick(FlickDirection.Right);
                            }
                        }
                        else
                        {
                            if (_gameManager.left1 != true && _unit > 0)
                            {
                                Flick(FlickDirection.Left);
                            }
                        }
                    }
                    // 縦方向
                    else
                    {
                        if (_gameManager.center1 != true && _unit > 0)
                        {
                            Flick(FlickDirection.Up);
                        }
                    }
                }
            }
        }
    }

    private void Flick(FlickDirection dir)
    {
        setUnitC = true;
        if (dir == FlickDirection.Left)
        {
            _selectUnit.SetUnit(-5, 2, 4);
            _gameManager.left1 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Right)
        {
            _selectUnit.SetUnit(5, 2, 4);
            _gameManager.right1 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Up)
        {
            _selectUnit.SetUnit(0, 2, 4);
            _gameManager.center1 = true;
            _unit -= 1;
        }
    }
}
