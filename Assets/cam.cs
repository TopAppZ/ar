using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cam : MonoBehaviour {
    private RawImage image;
    private WebCamTexture webcam;
    private AspectRatioFitter arf;
	// Use this for initialization
	void Start () {
        image = GetComponent<RawImage>();
        webcam = new WebCamTexture(Screen.width, Screen.height);
        image.texture = webcam;
        arf = GetComponent<AspectRatioFitter>();
        webcam.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(webcam.width < 100)
        {
            return;
        }
        /*float cwNeeded = -webcam.videoRotationAngle;
        if (webcam.videoVerticallyMirrored)
        {
            cwNeeded += 180f;
        }
        image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);
        float aspectRatio = (float)webcam.width / (float)webcam.height;
        arf.aspectRatio = aspectRatio;*/

		float ratio = (float)webcam.width / (float)webcam.height;
		arf.aspectRatio = ratio;
		float scaleY = webcam.videoVerticallyMirrored ? -1f : 1f;
		image.rectTransform.localScale = new Vector3 (1f, scaleY, 1f);
		int orient = -webcam.videoRotationAngle;
		image.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);

	}
}
