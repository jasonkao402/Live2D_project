using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowMouse : MonoBehaviour {
	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}