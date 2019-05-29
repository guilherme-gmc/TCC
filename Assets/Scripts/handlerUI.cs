using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class handlerUI : MonoBehaviour
{
    DirectoryInfo hudFolder;
    private int i;
    private GameObject Score;
    private Image hudImg;
    private string hudsPath;
    private Sprite[] hudSprites;

    // Use this for initialization
    void Start () {
        if(SceneTransitions._context == "gameCont" && Boss.lost) {
        hudsPath = "UI/HUD2";
        } else {
        hudsPath = "UI/HUD1";
        }
        Score = transform.Find("Score").gameObject;
        hudImg = Score.GetComponent<Image>();
        i = 0;

        hudSprites = Resources.LoadAll<Sprite>(hudsPath);

        UpdateScore();
    }
    public void UpdateScore() {
		hudImg.sprite = hudSprites[g.GetScore()];
	}


}
