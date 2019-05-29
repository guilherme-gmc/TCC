using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private int len;

    void Start()
    {
        len = hearts.Length;
        len--;
        UpdateHealth();
    }

    public void UpdateHealth() {
        for(int i = 0; i <= len; i++) {
            if(i >= g.maxHp) {
                hearts[len - i].enabled = false;
            } else {
                hearts[len - i].enabled = true;
            }

            if(i < g.hp) {
                hearts[len - i].sprite = fullHeart;
            } else {
                hearts[len - i].sprite = emptyHeart;
            }
        }
    }
}
