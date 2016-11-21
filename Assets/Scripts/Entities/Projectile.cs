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

	public int Damage {
		get {
			return this.damage;
		}
		set {
			damage = value;
		}
	}

	public Vector2 Direction {
		get {
			return this.direction;
		}
		set {
			direction = value;
		}
	}
}
