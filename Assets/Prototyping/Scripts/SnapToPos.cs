using UnityEngine;
using System.Collections;

public class SnapToPos : MonoBehaviour {

	public Transform SupposedCoordinatesTransform;

	private Vector3 supposedCoords = new Vector3(0f, 0f, 0f);
	// Update is called once per frame
	void FixedUpdate () {
		supposedCoords = SupposedCoordinatesTransform.transform.position;
		supposedCoords.y = supposedCoords.y - 1f;
		this.transform.position = supposedCoords;
	}
}
