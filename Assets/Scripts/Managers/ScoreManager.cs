using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text scoreLabel;

	private int score;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateScoreLabel ();
	}

	public int Score {
		get {
			return this.score;
		}
		set {
			score = value;
		}
	}

	void UpdateScoreLabel ()
	{
		scoreLabel.text = "Score: " + score;
	}
}
