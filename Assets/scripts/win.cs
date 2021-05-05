using UnityEngine;

public class win : MonoBehaviour {

	public GameObject winUI;
	public int nextLevel = 2;

	public void Win()
	{
		if (PlayerPrefs.GetInt ("levelReached", 1) < nextLevel) 
		{
			PlayerPrefs.SetInt ("levelReached", nextLevel);
		}

		winUI.SetActive (true);
	}
}
