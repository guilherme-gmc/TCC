using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuMensagens : MonoBehaviour {

    DirectoryInfo msgFolder;
    private int i;
    private GameObject msg;
    private Image msgImg;
    private string msgsPath;
    private Sprite[] msgSprites;

    // Use this for initialization
    void Start () {
        msgsPath = "Mensagens/";
        msg = GameObject.Find("Message");
        msgImg = msg.GetComponent<Image>();
        i = 0;

        msgSprites = Resources.LoadAll<Sprite>(msgsPath);

        SetSprite(i);
    }
	
	public void CarregarInicio() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
	}

    public void NextMessage() {
        SetSprite(i + 1);
    }

    public void PreviousMessage()
    {
        SetSprite(i - 1);
    }

    private void SetSprite(int index) {
        if (index == msgSprites.Length)
        {
            index = 0;
        } else if(index < 0)
        {
            index = msgSprites.Length - 1;
        }
        i = index;
        msgImg.sprite = msgSprites[index];
    }
}
