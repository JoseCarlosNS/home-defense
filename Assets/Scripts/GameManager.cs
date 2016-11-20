using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	private static GameManager instance;

	// Use this for initialization
	void Start ()
	{
		if (instance == null) {
			instance = this;
		}

		if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (instance);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public GameManager GetInstance ()
	{
		return instance;
	}
}
