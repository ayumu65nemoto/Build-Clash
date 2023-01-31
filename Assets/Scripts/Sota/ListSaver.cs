using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSaver : MonoBehaviour
{

    public List<GameObject> saveList = new List<GameObject>();
    public List<Vector3> PosList = new List<Vector3>();
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
