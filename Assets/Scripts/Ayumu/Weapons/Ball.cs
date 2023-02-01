using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
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
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStates>().hp -= 30;
        }

        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<PlayerStates>().hp -= 30;
        }
    }
}
