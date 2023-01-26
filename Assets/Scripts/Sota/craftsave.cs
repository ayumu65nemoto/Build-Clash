using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftsave : MonoBehaviour
{
    [SerializeField]
    GameObject block1;
    [SerializeField]
    GameObject block2;
    [SerializeField]
    GameObject block3;

    public static  craftsave notdouble;

    GameObject script;
    crafter craftOK;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if (notdouble == null)
        {
            notdouble = this;
            script = GameObject.Find("CraftManager");
            craftOK = script.GetComponent<crafter>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void SaveCastle()
    {

    }
}
