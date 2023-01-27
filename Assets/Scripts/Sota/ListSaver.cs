using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSaver : MonoBehaviour
{

    public List<GameObject> saveList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
