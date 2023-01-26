using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameObject glo;
    // Start is called before the first frame update
    void Start()
    {
        glo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            glo.gameObject.transform.position = new Vector3(1, 1, 1);
            glo.gameObject.SetActive(true);
        }
    }
}
