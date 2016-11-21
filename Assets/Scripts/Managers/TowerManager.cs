using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour
{

	public GameObject towerType;
	public Collider2D[] buildAreas;
	public GameObject buildPreview;

	private ResourceManager resourceManager;
	private GameObject preview;
	private bool canBuild;

	// Use this for initialization
	void Start ()
	{
		resourceManager = GameManager.GetInstance ().GetComponent<ResourceManager> ();
		canBuild = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Collider2D c2D in buildAreas) {
			if (c2D.bounds.Contains (InputManager.GetMousePosition ())) {
				canBuild = true;
				break;
			} else {
				canBuild = false;
			}
		}
		if (canBuild) {
			DrawPreview ();
			if (Input.GetMouseButtonDown (0)) {
				float cost = towerType.GetComponent<Tower> ().cost;
				if (resourceManager.Resource >= cost) {
					Instantiate (towerType, InputManager.GetMousePosition (), Quaternion.identity);
					resourceManager.Resource -= cost;
				}
			}
		} else {
			Destroy (preview);
		}
	}

	void DrawPreview ()
	{
		if (preview != null) {
			preview.transform.position = InputManager.GetMousePosition ();
		} else {
			preview = Instantiate (buildPreview, InputManager.GetMousePosition (), Quaternion.identity) as GameObject;
		}
	}
}
