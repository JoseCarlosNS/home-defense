using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
	public GameObject projectile;
	public GameObject turret;
	public GameObject baseGO;
	public GameObject projectilePoint;
	public int baseCA;
	public float baseAttSpd;

	private int ca, bonusCA;
	private float attSpd, bonusAttSpd, attTimer, secondsPerAtt;
	private bool isAttacking;
	private List<GameObject> targets;
	private GameObject currentTarget;

	// Use this for initialization
	void Start ()
	{
		bonusCA = 0;
		bonusAttSpd = 0f;

		UpdateStatusValues ();

		targets = new List<GameObject> ();

		attTimer = 0f;
		isAttacking = false;

		gameObject.transform.SetParent (GameObject.Find ("Towers").transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateCurrentTarget ();
		attTimer += (secondsPerAtt * Time.deltaTime);
		if (isAttacking && currentTarget != null) {
			FaceTarget ();
			if (attTimer >= secondsPerAtt) {
				LaunchAttack ();
				attTimer = 0f;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other != null & other.tag == "Enemy") {
			targets.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other != null && other.tag == "Enemy") {
			targets.Remove (other.gameObject);
		}
	}

	void FaceTarget ()
	{	 
		GameObject target = targets [0];
		Vector3 diff = target.transform.position - transform.position;
		diff.Normalize ();
 
		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		turret.transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);
	}

	void LaunchAttack ()
	{
		GameObject target = targets [0];
		Vector3 diff = target.transform.position - transform.position;
		diff.Normalize ();
		GameObject projectileInstance = Instantiate (projectile, 
			                                projectilePoint.transform.position,
			                                projectilePoint.transform.rotation) as GameObject;
		Projectile proj = projectileInstance.GetComponent<Projectile> ();
		proj.setDirection (diff);
		proj.SetDamage (ca);
	}

	void UpdateStatusValues ()
	{
		ca = baseCA + bonusCA;
		attSpd = baseAttSpd + bonusAttSpd;
		secondsPerAtt = 100 / attSpd;
	}

	void UpdateCurrentTarget ()
	{	
		if (targets.Count > 0) {
			while (targets [0] == null) {
				targets.RemoveAt (0);
			}
		}
		if (targets.Count > 0) {
			currentTarget = targets [0];
			isAttacking = true;
			return;
		}
		isAttacking = false;
		currentTarget = null;
	}
}
