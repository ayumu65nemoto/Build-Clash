using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPosition : MonoBehaviour
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
    //矢印格納
    public GameObject indicater_a;
    public GameObject indicater_b;
    public GameObject indicater_c;
    public SelectUnit selectUnit;

    // Start is called before the first frame update
    void Start()
    {
        //indicater_a = GameObject.FindWithTag("indicater_a");
        //indicater_b = GameObject.FindWithTag("indicater_b");
        //indicater_c = GameObject.FindWithTag("indicater_c");
        selectUnit = GetComponent<SelectUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 dif = Input.mousePosition - _clickStartPosition;

            //負の値を取る子ともあるのでAbsで絶対値に
            float abs_x = Mathf.Abs(dif.x);
            float abs_y = Mathf.Abs(dif.y);

            //閾値(反応する最小値)
            if (abs_x >= _threshold || abs_y >= _threshold)
            {
                // 横方向
                if (abs_x > abs_y)
                {
                    Flick(dif.x > 0 ? FlickDirection.Right : FlickDirection.Left);
                }
                // 縦方向
                else
                {
                    Flick(FlickDirection.Up);
                }
            }
        }
    }

    public void Flick(FlickDirection dir)
    {
        if (dir == FlickDirection.Left)
        {
            //indicater_a.SetActive(true);
            selectUnit.SetUnit(-2, 1, -2);
        }
        if (dir == FlickDirection.Right)
        {
            //indicater_b.SetActive(true);
            selectUnit.SetUnit(2, 1, -2);
        }
        if (dir == FlickDirection.Up)
        {
            //indicater_c.SetActive(true);
            selectUnit.SetUnit(0, 1, -5);
        }
    }
}
