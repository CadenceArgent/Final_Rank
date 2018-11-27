using UnityEngine;

public class CameraOrbit : MonoBehaviour {


	protected Transform _XForm_Camera;
	protected Transform _XForm_Anchor;


	protected Vector3 _LocalRotation;
	protected float _CameraDistance = 10f;

	public float MouseSensitivity = 4f;
	public float ScrollSensitivity = 2f;
	public float OrbitDampening = 10f;
	public float ScrollDampening = 4f;

	public bool CameraDisabled = false;

	public float ZoomMinimum = 4f;
	public float ZoomMaximum = 20f;


	// Use this for initialization
	void Start () {
		this._XForm_Camera = this.transform;
		this._XForm_Anchor = this.transform.parent;
	}
	
	// LateUpdate is called once per frame, after Update()
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			CameraDisabled = !CameraDisabled;
		}
		if (!CameraDisabled) {

			//Camera Orbit
			if (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0) {
				_LocalRotation.x += Input.GetAxis ("Mouse X") * MouseSensitivity;
				_LocalRotation.y -= Input.GetAxis ("Mouse Y") * MouseSensitivity;

				_LocalRotation.y = Mathf.Clamp (_LocalRotation.y, 0f, 90f);
			}

			//Camera Zooming
			if (Input.GetAxis ("Mouse ScrollWheel") != 0f) {
				float scrollAmount = Input.GetAxis ("Mouse ScrollWheel") * ScrollSensitivity;

				//Camera zooms faster when further away
				scrollAmount *= (this._CameraDistance * 0.3f);

				this._CameraDistance += scrollAmount * -1f;

				this._CameraDistance = Mathf.Clamp (this._CameraDistance, ZoomMinimum, ZoomMaximum);
			}
		}

		//Rig Orientations
		Quaternion at = Quaternion.Euler (_LocalRotation.y, _LocalRotation.x, 0);

		this._XForm_Anchor.rotation = Quaternion.Lerp (this._XForm_Anchor.rotation, at, Time.deltaTime * OrbitDampening);

		if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f) {
			this._XForm_Camera.localPosition = new Vector3 (0f, 0f, Mathf.Lerp (this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
		}
	}
}
