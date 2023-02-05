using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPositionB2 : MonoBehaviour
{
    public enum FlickDirection
    {
        Left,
        Right,
        Up,
    }

    Vector3 _clickStartPosition = Vector2.zero;
    //臒l
    [SerializeField] float _threshold = 30;
    private GameObject _gameObject;
    private GameManager _gameManager;
    private SelectUnit2 _selectUnit2;
    //���j�b�g�z�u�����t���O
    public bool setUnitB2;
    //���j�b�g�z�u��
    private int _unit;

    // Start is called before the first frame update
    void Start()
    {
        setUnitB2 = false;
        _unit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�^�b�v�����_���擾
            _clickStartPosition = Input.mousePosition;

            _gameObject = GameObject.FindWithTag("GameManager");
            _gameManager = _gameObject.GetComponent<GameManager>();
            _selectUnit2 = GameObject.Find("Canvas2").GetComponent<SelectUnit2>();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //�������_���擾���āA�^�b�v�����_�Ƃ̋����𑪂�
            Vector3 dif = Input.mousePosition - _clickStartPosition;

            //���̒l�����q�Ƃ�����̂�Abs�Ő�Βl��
            float abs_x = Mathf.Abs(dif.x);
            float abs_y = Mathf.Abs(dif.y);

            //臒l(��������ŏ��l)
            if (abs_x >= _threshold || abs_y >= _threshold)
            {
                if (_selectUnit2.push_b2 == true)
                {
                    // ������
                    if (abs_x > abs_y)
                    {
                        //Flick(dif.x > 0 ? FlickDirection.Right : FlickDirection.Left);
                        if (dif.x > 0)
                        {
                            if (_gameManager.right2 != true && _unit > 0)
                            {
                                Flick(FlickDirection.Right);
                            }
                        }
                        else
                        {
                            if (_gameManager.left2 != true && _unit > 0)
                            {
                                Flick(FlickDirection.Left);
                            }
                        }
                    }
                    // �c����
                    else
                    {
                        if (_gameManager.center2 != true && _unit > 0)
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
        setUnitB2 = true;
        if (dir == FlickDirection.Left)
        {
            _selectUnit2.SetUnit(-2.5f, 0, 7);
            _gameManager.left2 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Right)
        {
            _selectUnit2.SetUnit(2.5f, 0, 7);
            _gameManager.right2 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Up)
        {
            _selectUnit2.SetUnit(0, 0, -6);
            _gameManager.center2 = true;
            _unit -= 1;
        }
    }
}
