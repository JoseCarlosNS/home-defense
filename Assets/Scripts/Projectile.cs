using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float spd;

	private int damage;
	private Vector2 direction;
	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = direction * (spd / 100f);

		Destroy (gameObject, 3f);
	}

	public void setDirection (Vector2 direction)
	{
		this.direction = direction;
	}

	public void SetDamage (int ca)
	{
		damage = ca;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			Enemy enemy = other.GetComponent<Enemy> ();
			enemy.TakeDamage (damage);
			Destroy (gameObject);
		}
	}
}
