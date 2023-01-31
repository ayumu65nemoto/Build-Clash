using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    // 衝突した相手にPlayerタグが付いているとき
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Flame);
    //        if (collision.gameObject.GetComponent<PlayerStates>().state == PlayerStates.PlayerState.Wet)
    //        {
    //            collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Thunder);
    //            Debug.Log("sander");
    //        }

    //    }

    //    // 衝突した相手にPlayerタグが付いているとき
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Flame);
    //        if (collision.gameObject.GetComponent<PlayerStates2>().state2 == PlayerStates2.PlayerState.Wet)
    //        {
    //            collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Thunder);
    //            Debug.Log("sander");
    //        }
    //    }
    //}

    void OnTriggerEnter(Collider collider)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collider.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Flame);
            if (collider.gameObject.GetComponent<PlayerStates>().state == PlayerStates.PlayerState.Wet)
            {
                //collider.gameObject.GetComponent<PlayerStates>().SetState(PlayerStates.PlayerState.Thunder);
                //Debug.Log("sander");
                int number = Random.Range(1, 100);
                if (number <= 20)
                {
                    Destroy(collider.gameObject);
                }
            }

        }

        // 衝突した相手にPlayerタグが付いているとき
        if (collider.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Flame);
            if (collider.gameObject.GetComponent<PlayerStates2>().state2 == PlayerStates2.PlayerState.Wet)
            {
                //collider.gameObject.GetComponent<PlayerStates2>().SetState(PlayerStates2.PlayerState.Thunder);
                //Debug.Log("sander");
                int number = Random.Range(1, 100);
                if (number <= 20)
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
