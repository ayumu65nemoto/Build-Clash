using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�uCraft�v���uScanScene�v

public class Sample : MonoBehaviour
{
	public void OnClickStartButton()
	{
		SceneManager.LoadScene("ScanScene");
	}
}
