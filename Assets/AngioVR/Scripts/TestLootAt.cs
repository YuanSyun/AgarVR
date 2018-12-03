using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLootAt : MonoBehaviour {

    public Transform Target;
    public float ZAngle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.position, transform.up);
	}
}
