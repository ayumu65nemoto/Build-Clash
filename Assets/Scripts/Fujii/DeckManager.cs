using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;
    public GameObject[] DeckArrays = new GameObject[3];

    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Craft");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
