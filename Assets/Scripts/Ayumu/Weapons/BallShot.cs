using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private GameObject _gameObject;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.FindWithTag("GameManager");
        _gameManager = _gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _count += 1;

        if (_gameManager.battle == true)
        {
            // ‚U‚OƒtƒŒ[ƒ€‚²‚Æ‚É–C’e‚ğ”­Ë‚·‚é
            if (_count % 420 == 0)
            {
                GameObject ball = Instantiate(prefab, transform.position, Quaternion.identity);
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();

                // ’e‘¬‚Í©—R‚Éİ’è
                ballRb.AddForce(transform.forward * 1500);

                //// ”­Ë‰¹‚ğo‚·
                //AudioSource.PlayClipAtPoint(sound, transform.position);

                // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
                Destroy(ball, 2.0f);
            }
        }
    }
}
