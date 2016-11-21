using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public static Vector2 GetMousePosition ()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 pos = new Vector2 ();

		pos.x = mousePos.x;
		pos.y = mousePos.y;

		return pos;
	}
}
