using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public string name, description;
	public float hp, cd, ca, spd;

	private Rigidbody2D rb2d;
	private float spdPerSec;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector3 (-1, 0, 0);
		spdPerSec = 100f / spd;
	}

	public void TakeDamage (int ca)
	{
		float percentTaken = (100 - cd) / 100f;
		float damageTaken = ca * percentTaken;
		hp -= damageTaken;
		IsDead ();
	}

	void IsDead ()
	{
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
}
