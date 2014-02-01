using UnityEngine;
using System.Collections;

public class MotionScript : MonoBehaviour {
	public float angleinc=100.0F;
	Vector3 heading;
	public float accel=10f;
	public float curaccel;
	public float curvelocity;
	public float deccel=.8f;
	public float positionx;
	public float positiony;
	public float theta;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		theta = gameObject.transform.eulerAngles.z;
		heading = gameObject.transform.right;
		positionx = gameObject.transform.position.x;
		positiony = gameObject.transform.position.y;
		if ((curaccel < 1) && (curaccel > -1))
						curaccel = 0;
		else 
						curaccel *= deccel;
	
	if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Rotate(0,0,-angleinc * Time.deltaTime);
				}
	if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Rotate(0,0,+angleinc * Time.deltaTime);
		}
	if (Input.GetKey (KeyCode.UpArrow)) {
			if (curaccel<(100)) curaccel+=accel;
		}
	if (Input.GetKey (KeyCode.DownArrow)) {
			if (curaccel>(-100)) curaccel-=accel;
			
		}
		heading = gameObject.transform.right;
		curvelocity = curaccel * Time.deltaTime;
		gameObject.transform.Translate (heading * curvelocity* Time.deltaTime,Space.World);
	}
}
