using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public MyCube myCube0;
    public MyCube myCube1;

	// Use this for initialization
	void Start () {
        Observer.AddListener(TestEvent.JUMP, myCube0, myCube0.Jump);
        Observer.AddListener(TestEvent.JUMP, myCube1, myCube1.Jump);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
            Observer.SendMessage(TestEvent.JUMP, 200f);
        }

        
	}
}
