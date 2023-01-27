using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPositionA : MonoBehaviour
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
    private GameObject _gameManager;
    private SelectUnit _selectUnit;
    //ユニット配置完了フラグ
    public bool setUnitA;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager");
        _selectUnit = _gameManager.GetComponent<SelectUnit>();
        setUnitA = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //タップした点を取得
            _clickStartPosition = Input.mousePosition;
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
                if (_selectUnit.push_a == true)
                {
                    // 横方向
                    if (abs_x > abs_y)
                    {
                        //Flick(dif.x > 0 ? FlickDirection.Right : FlickDirection.Left);
                        if (dif.x > 0)
                        {
                            Flick(FlickDirection.Right);
                        }
                        else
                        {
                            Flick(FlickDirection.Left);
                        }
                    }
                    // 縦方向
                    else
                    {
                        Flick(FlickDirection.Up);
                    }
                }
            }
        }
    }

    private void Flick(FlickDirection dir)
    {
        setUnitA = true;
        if (dir == FlickDirection.Left)
        {
            _selectUnit.SetUnit(-10, 1, 4);
        }
        else if (dir == FlickDirection.Right)
        {
            _selectUnit.SetUnit(10, 1, 4);
        }
        else if (dir == FlickDirection.Up)
        {
            _selectUnit.SetUnit(0, 1, 3);
        }
    }
}
