﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

	public Transform objToFollow;
	public float lookSpeed = 10.0f;
	public float folloSpeed = 10.0f;
	public Vector3 offSet;

	private void FixedUpdate() {
		LookAt();
		Follow();
	}

	void LookAt()
	{
		Vector3 _lookDir = objToFollow.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(_lookDir, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
	}

	void Follow()
	{
		Vector3 _targetPos = objToFollow.position + 
							( objToFollow.forward * offSet.z + objToFollow.right * offSet.x + objToFollow.up * offSet.y );
			
			transform.position = Vector3.Lerp(transform.position, _targetPos, folloSpeed * Time.deltaTime);
	}

}
