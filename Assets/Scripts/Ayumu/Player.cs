using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStates _playerStates;

    // Start is called before the first frame update
    void Start()
    {
        _playerStates = GetComponent<PlayerStates>();
    }

    //Å@ìñÇΩÇ¡ÇΩÇÁîjâÛÇ∑ÇÈ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flame"))
        {
            _playerStates.SetState(PlayerStates.PlayerState.Flame);
            //Destroy(gameObject, 0.2f);
        }
    }
}
