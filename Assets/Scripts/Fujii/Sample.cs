using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//「Craft」→「ScanScene」

public class Sample : MonoBehaviour
{
	public void OnClickStartButton()
	{
		SceneManager.LoadScene("ScanScene");
	}
}
