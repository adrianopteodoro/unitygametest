using UnityEngine;
using System.Collections;

public class DayNightTransition : MonoBehaviour
{
	public Color dayColor;
	public Color nightColor;

	public float duration = 50f;
	float lastTime;
	Light lt;
	public bool isDay;
	public float speed = 0.3f;
	public Color color;
	Quaternion rot;

	void Awake()
	{
		lt = GetComponent<Light>();
		isDay = true;
		color = dayColor;
		rot = transform.rotation;
	}

	void Update()
	{
		// argument for cosine
		float phi = Time.time / duration * 2 * Mathf.PI;
		
		// get cosine and transform from -1..1 to 0..1 range
		float amplitude = (float)(Mathf.Cos( phi ) * 0.5 + 0.5);
		
		// set light color
		lt.intensity = amplitude;
	}

	void FixedUpdate()
	{
		lastTime += Time.deltaTime;

		lt.color = Color.Lerp(lt.color, color, speed * Time.deltaTime);

		if (lastTime >= duration)
		{
			lastTime = 0f;
			if(isDay)
			{
				color = nightColor;
				isDay = false;
			}
			else
			{
				color = dayColor;
				isDay = true;
			}
		}
	}
}
