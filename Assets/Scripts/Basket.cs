using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    private Text scoreCounter;

	// Use this for initialization
	void Start () {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<Text>();
        UpdateScore(0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition2D = Input.mousePosition;
        mousePosition2D.z = -Camera.main.transform.position.z;
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePosition3D.x;
        this.transform.position = pos;
	}

    void OnCollisionEnter(Collision collider) {
        GameObject collidedWith = collider.gameObject;
        if (collidedWith.CompareTag("Apple")) 
        {
            Destroy(collidedWith);
            UpdateScore(100);
        }
        else if (collidedWith.CompareTag("Orange"))
        {
            Destroy(collidedWith);
            UpdateScore(250);
        }
    }

    void UpdateScore(int scoreMod) {
        var score = int.Parse(scoreCounter.text.Substring(7)) + scoreMod;
        scoreCounter.text = "Score: " + score;

        PlayerPrefs.SetInt("ApplePickerCurrentScore", score);

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
