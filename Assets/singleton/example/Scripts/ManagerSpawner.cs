using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSpawner : MonoBehaviour
{
	public GameObject Manager;
	public Text DebugText;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Manager);
			DebugText.text = "If you press space again, a warning will tell you the new instance failed, because it is a singleton.\n\nThis is great for scripts like Managers, that you only want to exist once, and to easily be accessed by other scripts.";
		}	
	}
}
