using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public string name, description;
	public float maxHP, cd, ca, spd;
	public GameObject lifeBar;
	public int scoreValue;

	private Rigidbody2D rb2d;
	private float spdValue;
	private float hp;
	private ScoreManager scoreManager;
	private ResourceManager resourceManager;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		scoreManager = GameManager.GetInstance ().GetComponent<ScoreManager> ();
		resourceManager = GameManager.GetInstance ().GetComponent<ResourceManager> ();

		spdValue = spd / 100;
		rb2d.velocity = new Vector3 (-1f * spdValue, 0, 0);
		hp = maxHP;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Projectile") {
			Projectile proj = other.GetComponent<Projectile> ();
			TakeDamage (proj.Damage);
			Destroy (other.gameObject);
		} else if (other.tag == "House Area") {
			GameManager.GetInstance ().Health -= ca;
			GameManager.GetInstance ().UpdateHealth ();
			Destroy (gameObject);
		}
	}

	public void TakeDamage (float ca)
	{
		float percentTaken = (100 - cd) / 100f;
		float damageTaken = ca * percentTaken;
		hp -= damageTaken;
		lifeBar.transform.localScale = new Vector3 (1, hp / maxHP, 1);
		IsDead ();
	}

	void IsDead ()
	{
		if (hp <= 0) {
			scoreManager.Score += scoreValue;
			resourceManager.Resource += (ca / 2);
			Destroy (gameObject);
		} 
	}
}
