using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float startingHealth;
	public Text healthLabel, gameOverLabel;

	private static GameManager instance;
	private float health;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}

		if (instance != this) {
			Destroy (gameObject);
		}

		health = startingHealth;	

		UpdateHealth ();

		DontDestroyOnLoad (instance);
	}

	public void UpdateHealth ()
	{
		healthLabel.text = "Health: " + health;
		if (health <= 0) {
			gameOverLabel.gameObject.SetActive (true);
			gameObject.SetActive (false);
		}
	}

	public float Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}

	public static GameManager GetInstance ()
	{
		return instance;
	}
}
