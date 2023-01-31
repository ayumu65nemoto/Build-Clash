using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ThunderPlane : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collider.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Flame);
            if (collider.gameObject.GetComponent<PlayerStates>().state == PlayerStates.PlayerState.Wet)
            {
                collider.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Thunder);
            }

        }

        // 衝突した相手にPlayerタグが付いているとき
        if (collider.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Flame);
            if (collider.gameObject.GetComponent<PlayerStates2>().state2 == PlayerStates2.PlayerState.Wet)
            {
                collider.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Thunder);
            }
        }
    }
}
