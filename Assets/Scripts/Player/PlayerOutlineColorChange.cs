using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutlineColorChange : MonoBehaviour
{
    public Color baseColor;
    public Color neonColor;
	public float changeSpeed;

	Color color;
	float lastTime;
	
	Renderer playerRenderer;

	// Start is called before the first frame update
	void Start()
    {
		playerRenderer = GetComponent<Renderer>();
		color = neonColor;
		changeSpeed = 2f;
	}

    // Update is called once per frame
    void Update()
    {
		lastTime += Time.deltaTime;

		if (lastTime >= 2f)
		{
			lastTime = 0f;
			if (playerRenderer.material.GetColor("_OutlineColor") == baseColor)
			{
				color = neonColor;
				playerRenderer.material.SetColor("_OutlineColor", baseColor);
			}
			else if (playerRenderer.material.GetColor("_OutlineColor") == neonColor)
			{
				color = baseColor;
				playerRenderer.material.SetColor("_OutlineColor", neonColor);
			}
		}

		playerRenderer.material.SetColor("_OutlineColor", Color.Lerp(playerRenderer.material.GetColor("_OutlineColor"), color, changeSpeed * Time.deltaTime));
	}

	void FixedUpdate()
	{
	}
}
