using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuMensagens : MonoBehaviour {

	//Abaixo tem uma lista com 10 frases.
	/*string mensagens [] = new string ["\"Você provavelmente terá de entrar em uma batalha mais de uma vez para vencê-la\" -Margaret Thatcher", "\"Quanto maior o artista, maiores são os momentos de dúvida. Confiança inabalável é algo garantido para os menos talentosos, como um prêmio de consolação\" - Robert Hughes", "\"Seja feliz com o que você tem, mas fique animado com a chance de ter mais\" – Alan Cohen", "\"Somos nós que forjamos as correntes que usamos em nossas vidas\" – Charles Dickens", "\"Em nossas vidas, a mudança é inevitável. A perda é inevitável. A felicidade reside na nossa adaptabilidade em sobreviver a tudo de ruim\" – Buda", "\"Para cuidar de si mesmo, use a cabeça. Para cuidar dos outros, use seu coração\" – Eleanor Roosevelt","\"Sempre lembre que você é mais corajoso do que pensa, mais forte do que parece e mais esperto do que acredita\". – Christopher Robin", "\"Se você quer vencer, não fique olhando a escada. Comece a subir, degrau por degrau, até chegar ao topo.\" - Desconhecido",
		"\"Seu tempo é curto. Por isso, não o desperdice vivendo a vida de outra pessoa\" – Steve Jobs", "\"Procure suas qualidades, acredite em você, não fique pensando que os outros sabem mais que você. Acredite em seu poder.\" - Zibia"] ;*/

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
