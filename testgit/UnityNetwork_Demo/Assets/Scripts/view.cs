﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour {

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes m_axes = RotationAxes.MouseXAndY;
	public float m_sensitivityX = 1f;
	public float m_sensitivityY = 1f;
	//水平方向的镜头转向
	public float m_minimumX = -360f;
	public float m_maximumX = 360f;
	//垂直方向的镜头转向 （最大仰角45°）
	public float m_minimumY = -60f;
	public float m_maximumY = 60f;

	float m_rotationY = 0f;

	// Use this for initialization
	void Start () {
		// 防止刚体影响镜头旋转
		if (GetComponent<Rigidbody>()){
			GetComponent<Rigidbody> ().freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (m_axes == RotationAxes.MouseXAndY) {
			float m_rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * m_sensitivityX;
			m_rotationY += Input.GetAxis ("Mouse Y") * m_sensitivityY;
			m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);

			transform.localEulerAngles = new Vector3 (-m_rotationY, m_rotationX, 0);
		} else if (m_axes == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * m_sensitivityX, 0);
		} else {
			m_rotationY += Input.GetAxis ("Mouse Y") * m_sensitivityY;
			m_rotationY = Mathf.Clamp (m_rotationY, m_minimumY, m_maximumY);

			transform.localEulerAngles = new Vector3 (-m_rotationY, transform.localEulerAngles.y, 0);
		}
}
}