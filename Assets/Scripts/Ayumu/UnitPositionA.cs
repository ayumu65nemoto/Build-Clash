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
    //臒l
    [SerializeField] float _threshold = 30;
    private GameObject _gameObject;
    private SelectUnit _selectUnit;
    private GameManager _gameManager;
    //���j�b�g�z�u�����t���O
    public bool setUnitA;
    //���j�b�g�z�u��
    private int _unit;

    // Start is called before the first frame update
    void Start()
    {
        //_gameObject = GameObject.FindWithTag("GameManager");
        //_selectUnit = _gameObject.GetComponent<SelectUnit>();
        //_gameManager = _gameObject.GetComponent<GameManager>();
        setUnitA = false;
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
            _selectUnit = _gameObject.GetComponent<SelectUnit>();
            _gameManager = _gameObject.GetComponent<GameManager>();
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
                if (_selectUnit.push_a == true)
                {
                    // ������
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
                    // �c����
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
        setUnitA = true;
        if (dir == FlickDirection.Left)
        {
            _selectUnit.SetUnit(-5, 1, 2);
            _gameManager.left1 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Right)
        {
            _selectUnit.SetUnit(5, 1, 2);
            _gameManager.right1 = true;
            _unit -= 1;
        }
        else if (dir == FlickDirection.Up)
        {
            _selectUnit.SetUnit(0, 1, 2);
            _gameManager.center1 = true;
            _unit -= 1;
        }
    }
}
