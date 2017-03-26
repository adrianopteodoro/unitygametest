using UnityEngine;
using System.Collections;

public class PlayerName : MonoBehaviour
{
	void LastUpdate()
	{
		GetComponent<TextMesh>().text = "Changed";
	}
}
