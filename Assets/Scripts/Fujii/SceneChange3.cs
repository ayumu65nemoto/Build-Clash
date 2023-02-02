using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange3 : MonoBehaviour
{
	public void OnClickStartButton()
	{
		SceneManager.LoadScene("BattleAR");
	}
}
