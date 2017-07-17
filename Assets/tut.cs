using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tut : MonoBehaviour {
    public float power = 1000.0f;
    private Vector3 startPos;
    void Start () {
        
        
    }	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnMouseDown()
    {
        startPos = Input.mousePosition;
        transform.rotation = Quaternion.identity;
    }
}
