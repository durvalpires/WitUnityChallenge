using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform t in GetComponentsInChildren<Transform>()){
            if(t.gameObject.name == "InputField Input Caret")
            {
                //t.gameObject.transform.localScale = new Vector3(0.05f, 1f, 1f);
            }
        } 
            

    }
}
