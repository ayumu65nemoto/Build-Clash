using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPositionA2 : MonoBehaviour
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
    private GameObject _gameManager;
    private SelectUnit2 _selectUnit2;
    //���j�b�g�z�u�����t���O
    public bool setUnitA2;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager");
        _selectUnit2 = _gameManager.GetComponent<SelectUnit2>();
        setUnitA2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�^�b�v�����_���擾
            _clickStartPosition = Input.mousePosition;
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
                if (_selectUnit2.push_a2 == true)
                {
                    // ������
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
                    // �c����
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
        setUnitA2 = true;
        if (dir == FlickDirection.Left)
        {
            _selectUnit2.SetUnit(-10, 1, -7);
        }
        else if (dir == FlickDirection.Right)
        {
            _selectUnit2.SetUnit(10, 1, -7);
        }
        else if (dir == FlickDirection.Up)
        {
            _selectUnit2.SetUnit(0, 1, -6);
        }
    }
}
