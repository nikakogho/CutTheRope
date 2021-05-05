using UnityEngine;
using UnityEngine.UI;

public class levelSelector : MonoBehaviour {

	public Sprite Lock;
	public Button[] buttons;

	void Start()
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			if (i > PlayerPrefs.GetInt ("lastLevelReached", 1) - 1) 
			{
				DisableButton (buttons [i]);


				if (i < PlayerPrefs.GetInt ("levelReached", 1)) 
				{
					EnableButton (buttons [i]);
				}
			}
		}

		PlayerPrefs.SetInt ("lastLevelReached", PlayerPrefs.GetInt ("levelReached"));
	}

	void DisableButton(Button button)
	{
		button.interactable = false;
	}

	void EnableButton(Button button)
	{
		button.enabled = true;
		button.GetComponent<Animator> ().SetTrigger ("Enabled");
	}
}
