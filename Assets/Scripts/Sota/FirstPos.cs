using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPos : MonoBehaviour
{
    public Vector3 F_Pos;
    public bool StartPos = true;
    float x, z,x_c, z_c;


    //èâä˙à íuól
    GameObject CraftManager;
    crafter Crafter;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        CraftManager = GameObject.Find("CraftManager");
        Crafter = CraftManager.GetComponent<crafter>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(StartPos==true&&Crafter.spawnCount==true)
        { 
            x = F_Pos.x;
            z = F_Pos.z;
            if (x < 1)
            {
                while (x < 1)
                {
                    x += 1f;
                    x_c -= 1f;
                }
            }
            else if (x>1)
            {
                while (x > 1)
                {
                    x -= 1f;
                    x_c += 1f;
                }
            }
        }
        if(z<1)
        {
            while (z < 1)
            {
                z += 1f;
                z -= 1f;
            }
        }
        else if (z > 1)
        {
            while (z > 1)
            {
                z -= 1f;
                z_c += 1f;
            }
        }
        StartPos = false;
    }
}
