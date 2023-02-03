using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class FlameShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;
    private GameObject _gameObject;
    private GameManager _gameManager;
    //”­Ë‰¹
    [SerializeField] private AudioClip flameSound;

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
            if (_count % 80 == 0)
            {
                GameObject flame = PhotonNetwork.Instantiate("Flame", transform.position, Quaternion.identity);
                Rigidbody flameRb = flame.GetComponent<Rigidbody>();

                // ’e‘¬‚Í©—R‚Éİ’è
                flameRb.AddForce(transform.forward * 10, ForceMode.Impulse);

                // ”­Ë‰¹‚ğo‚·
                AudioSource.PlayClipAtPoint(flameSound, transform.position);

                // 5•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
                Destroy(flame, 5.0f);
            }
        }
    }
}
