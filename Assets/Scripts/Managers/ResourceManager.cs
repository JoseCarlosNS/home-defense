using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
	public Text resourceLabel;

	private float resource;

	// Use this for initialization
	void Start ()
	{
		Resource = 20000;
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateResourcesLabel ();
	}

	public float Resource {
		get {
			return this.resource;
		}
		set {
			resource = value;
		}
	}

	void UpdateResourcesLabel ()
	{
		resourceLabel.text = "Resources: $$" + Resource;
	}
}
