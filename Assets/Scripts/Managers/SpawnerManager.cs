using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{
	public GameObject[] spawners;
	public GameObject[] enemies;
	public float[] enemyWaitTimes;

	private float[] enemyWaitCounter;

	void Start ()
	{
		enemyWaitCounter = new float[enemies.Length];
		for (int i = 0; i < enemyWaitCounter.Length; i++) {
			enemyWaitCounter [i] = 0;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		UpdateCounters ();
		for (int i = 0; i < enemyWaitCounter.Length; i++) {
			if (enemyWaitCounter [i] >= enemyWaitTimes [i]) {
				SpawnEnemy (i);
				enemyWaitCounter [i] = 0;
			}
		}
	}

	void ResetCounters ()
	{
		for (int i = 0; i < enemyWaitCounter.Length; i++) {
			enemyWaitCounter [i] = 0;
		}
	}

	void UpdateCounters ()
	{
		for (int i = 0; i < enemyWaitCounter.Length; i++) {
			enemyWaitCounter [i] += Time.deltaTime;
		}
	}

	void SpawnEnemy (int enemyID)
	{
		int id = Random.Range (0, spawners.Length);
		Transform tfm = spawners [id].transform;

		GameObject enemyInstance = Instantiate (enemies [enemyID], tfm.position, tfm.rotation) as GameObject;

		enemyInstance.transform.SetParent (GameObject.Find ("Enemies").transform);
	}
}
