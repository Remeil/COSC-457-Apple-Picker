using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var highScoreText = this.GetComponent<Text>();
	    var highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
	    var playerScore = PlayerPrefs.GetInt("ApplePickerCurrentScore");

	    var textString = "Your Score: " + playerScore + Environment.NewLine;
	    textString += "High Score: " + highScore + Environment.NewLine;

	    if (playerScore >= highScore)
	    {
	        textString += "New High Score!";
	    }

	    highScoreText.text = textString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
