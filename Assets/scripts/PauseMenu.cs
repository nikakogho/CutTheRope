using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public void Toggle()
	{
		PauseUI.SetActive (!PauseUI.activeSelf);

		if (PauseUI.activeSelf) 
		{
			Time.timeScale = 0;
		} else 
		{
			Time.timeScale = 1;
		}
	}
}
