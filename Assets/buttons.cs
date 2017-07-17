using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttons : MonoBehaviour {

    // Use this for initialization
    public Button info;
    public Button score;
    public GameObject infoPanel;    
    private bool isInfoShown;

    public Text heading;
    public Text body;

    void Start () {
        isInfoShown = false;        
        infoPanel.gameObject.SetActive(isInfoShown);
        info.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        score.GetComponent<Button>().onClick.AddListener(ScoreOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void TaskOnClick()
    {        
        isInfoShown = !isInfoShown;
        infoPanel.gameObject.SetActive(isInfoShown);
        body.fontSize = 32;
        heading.text = "About the Place";
        body.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ullamcorper erat arcu, at laoreet eros posuere id. Praesent pretium a eros a ornare. Praesent libero libero, feugiat ut velit vitae, tempor suscipit arcu.";
    }

    void ScoreOnClick()
    {        
        isInfoShown = !isInfoShown;
        infoPanel.gameObject.SetActive(isInfoShown);
        heading.text = "Your Score";
        body.fontSize = 120;
        body.text = "75";
    }
}
