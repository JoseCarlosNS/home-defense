using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public string name, description;
	public float maxHP, cd, ca, spd;
	public GameObject lifeBar;

	private Rigidbody2D rb2d;
	private float spdValue;
	private float hp;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		spdValue = spd / 100;
		rb2d.velocity = new Vector3 (-1f * spdValue, 0, 0);
		hp = maxHP;
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
		} else {
			lifeBar.transform.localScale = new Vector3 (1, hp / maxHP, 1);
		}
	}
}
