using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {
    private Gyroscope gyro;
    private bool isGyroSupported;
    private Quaternion rotfix;
	// Use this for initialization
	void Start () {
        isGyroSupported = SystemInfo.supportsGyroscope;
        GameObject camParent = new GameObject("camparent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;
        if (isGyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            camParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            rotfix = new Quaternion(0, 0, 1, 0);


        }
        
        
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = gyro.attitude * rotfix;        
    }
}
