using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	private static GameManager instance;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}

		if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (instance);
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public static GameManager GetInstance ()
	{
		return instance;
	}
}
