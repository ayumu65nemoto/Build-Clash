using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Flame);
            if (collision.gameObject.GetComponent<PlayerStates>()._state != PlayerStates.PlayerState.Wet)
            {
                collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Flame);
            }

        }

        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Flame);
            if (collision.gameObject.GetComponent<PlayerStates2>()._state != PlayerStates2.PlayerState.Wet)
            {
                collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Flame);
            }
        }
    }
}
