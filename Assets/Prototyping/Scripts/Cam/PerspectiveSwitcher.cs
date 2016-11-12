using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
	private Matrix4x4   ortho,
	perspective;
	public float        fov     = 60f,
	near    = .3f,
	far     = 1000f,
	orthographicSize = 50f;
	private float       aspect;
	private MatrixBlender blender;
	private bool        orthoOn;
	public bool PerspStarted;

	void Start()
	{
		aspect = (float) Screen.width / (float) Screen.height;
		ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
		perspective = Matrix4x4.Perspective(fov, aspect, near, far);
		this.GetComponent<Camera>().projectionMatrix = perspective;
		orthoOn = true;
		blender = (MatrixBlender) GetComponent(typeof(MatrixBlender));
	}

	private float TimePassed;
	private float TimeNeeded;
	private bool DuringTransition = false;
	void Update()
	{
		if (PerspStarted)
		{
			
			Transition(ortho, 1.5f);
			this.GetComponent<PerspectiveSwitcher> ().enabled = false;
		}
	}

	private void Transition (Matrix4x4 projectionType, float duration) {
		blender.BlendToMatrix (projectionType, duration);
		DuringTransition = true;
	}

}
