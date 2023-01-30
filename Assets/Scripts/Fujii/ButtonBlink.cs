using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBlink : MonoBehaviour
{
    //�{�^���̃R���|�[�l���g
    Button button;

    //�J�E���^
    int cnt;

    //�_�ł̑�����ݒ�(60�̏ꍇ�A30�t���[�����ƂɐF���ς��)
    public int MAX_COUNT = 60;

    //�_�ŐF�̐ݒ�
    public List<Color> colors = new List<Color>() { new Color(1, 1, 1, 1), new Color(1, 1, 0, 1) };

    // Start is called before the first frame update
    void Start()
    {
        //�{�^���̃R���|�[�l���g��ݒ�
        button = GetComponent<Button>();
        //�J�E���^�̏����l��0�ɐݒ�
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;
        cnt %= MAX_COUNT;
        var cls = button.colors;
        cls.normalColor = colors[cnt / (MAX_COUNT / colors.Count)];
        button.colors = cls;
    }
}
