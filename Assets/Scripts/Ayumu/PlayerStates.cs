using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public enum PlayerState
    {
        Normal,
        Flame
    }

    private PlayerState _state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(PlayerState tempState, Transform targetObj = null)
    {
        _state = tempState;

        if (tempState == PlayerState.Flame)
        {
            Debug.Log("Flame");
            Destroy(this.gameObject, 5f);
        }
    }
}
