﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g : MonoBehaviour
{
    private static int score = 0;
    public static int maxScore = 10;
    public static Vector2 iHspd = new Vector2(-350f, 0f);
    public static Vector2 fHspd = new Vector2(-750f, 0f);
    public static Vector2 iBgspd = new Vector2(300f, 0f);
    public static Vector2 fBgspd = new Vector2(650f, 0f);
    public static float spdMult = 1.75f;

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
