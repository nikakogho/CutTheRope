using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private PauseMenu pause;
	private win Win;

	void Awake()
	{
		Win = FindObjectOfType<win> ();
		pause = FindObjectOfType<PauseMenu> ();
	}

	void Update() 
	{
		if (Input.GetKeyDown ("r")) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		if (Input.GetKeyDown ("p") || Input.GetKeyDown ("escape")) 
		{
			pause.Toggle ();
		}
	}

	public void NextLevel()
	{
		SceneManager.LoadScene ("level" + Win.nextLevel);
	}

	public void Menu() 
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void LevelSelector()
	{
		SceneManager.LoadScene ("LevelSelector");
	}

	public void Reset()
	{
		PlayerPrefs.DeleteAll ();
	}

	public void PlayScene(string name)
	{
		SceneManager.LoadScene (name);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
