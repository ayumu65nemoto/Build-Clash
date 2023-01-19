using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameShot : MonoBehaviour
{
    public GameObject prefab;
    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _count += 1;

        // ‚U‚OƒtƒŒ[ƒ€‚²‚Æ‚É–C’e‚ğ”­Ë‚·‚é
        if (_count % 900 == 0)
        {
            GameObject flame = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody flameRb = flame.GetComponent<Rigidbody>();

            // ’e‘¬‚Í©—R‚Éİ’è
            flameRb.AddForce(transform.forward * 100);

            //// ”­Ë‰¹‚ğo‚·
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // 5•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
            Destroy(flame, 5.0f);
        }
    }
}
