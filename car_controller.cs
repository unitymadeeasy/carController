using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class car_controller : MonoBehaviour {

	public Transform frontDriver, frontpass, backdriver, backpass;
	public WheelCollider wheelfront_driver, wheelfront_pass, wheelback_driver, wheelback_pass;
	public float maxsteerangle = 30.0f;
	public float motorForce = 1500.0f;

	//public AudioSource a,b;

	float m_horizontal;
	float m_vertical;
	float m_steer;

	private void FixedUpdate() {
		getInput();
		steet();
		Drive();
		Updatewheelpos();
	}

	void getInput(){
		m_horizontal = Input.GetAxis("Horizontal");
		m_vertical = Input.GetAxis("Vertical");
		
		if(Input.GetKeyDown(KeyCode.W)){
			//a.Play();
			//b.Stop();
		}	
		if(Input.GetKeyUp(KeyCode.W)){
			//a.Stop();
			//b.Play();
		}
		
	}

	void steet(){
		m_steer = maxsteerangle * m_horizontal;
		wheelfront_driver.steerAngle = m_steer;
		wheelfront_pass.steerAngle = m_steer;
	}

	void Drive(){
		wheelback_driver.motorTorque = m_vertical * motorForce;
		wheelback_pass.motorTorque = m_vertical * motorForce;
	}

	void Updatewheelpos(){
			Updatewheelpos_common(wheelfront_driver,frontDriver);
			Updatewheelpos_common(wheelfront_pass,frontpass);
			Updatewheelpos_common(wheelback_driver,backdriver);
			Updatewheelpos_common(wheelback_pass,backpass);
	}

	void Updatewheelpos_common(WheelCollider col, Transform t){
		Vector3 p = t.position;
		Quaternion rot = t.rotation;
		col.GetWorldPose(out p, out rot);
		t.position = p;
		t.rotation = rot;
	}

}
