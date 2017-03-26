using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{	
	Transform player;
	float distance = 10.0f;
	float xSpeed = 120.0f;
	float ySpeed = 120.0f;
	float yMinLimit = -20f;
	float yMaxLimit = 80f;
	float distanceMin = 2.5f;
	float distanceMax = 15f;
	float x = 0.0f;
	float y = 0.0f;
	Vector3 playerPosition;
	Quaternion rotation;
	Vector3 position;
	
	// Use this for initialization
	void Awake() 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerPosition = player.position;
		rotation = transform.rotation;
		position = transform.position;
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>() != null)
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	void LateUpdate() 
	{
		if (player) 
		{
			// copya player posotion i dont want to change it
			playerPosition = player.position;
			// fix cam view at position.y 1.6f, i dont want to zoom it to the foots
			playerPosition.y += 1.6f;

			if (Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			}
			
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			rotation = Quaternion.Euler(y, x, 0);
			transform.rotation = rotation;
			
			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			position = rotation * negDistance + playerPosition;

			transform.position = position;
		}
	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}