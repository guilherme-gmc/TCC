using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g : MonoBehaviour
{
    private static int score = 0;
    public static int maxScore = 1;
    public static Vector2 hspd = new Vector2(-300f, 0f);

    public static float bulletDmg = 2f;


    public static void ScoreInc() {
        score++;
        GameObject.Find("Canvas").GetComponent<handlerUI>().UpdateScore();
        if(score == maxScore) {
            GameObject.Find("Canvas").GetComponent<SceneTransitions>().ChangeScene("gameNext");
        }
    }

    public static int GetScore() {
        return score;
    }

    public static void ResetScore() {
        score = 0;
    }
}
