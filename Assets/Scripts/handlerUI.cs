using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class handlerUI : MonoBehaviour
{
    private Text scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScore();
    }

    public void UpdateScore() {
		scoreText.text = "Chocolates: " + g.score + "/" + g.maxScore;
	}
}
