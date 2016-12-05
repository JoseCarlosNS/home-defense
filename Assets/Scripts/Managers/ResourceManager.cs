using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
	public Text resourceLabel;

	public float resource;

	// Use this for initialization
	void Start ()
	{
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
