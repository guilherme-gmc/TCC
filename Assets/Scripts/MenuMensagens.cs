using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuMensagens : MonoBehaviour {

	//Abaixo tem uma lista com 10 frases.
	/*string mensagens [] = new string ["\"Você provavelmente terá de entrar em uma batalha mais de uma vez para vencê-la\" -Margaret Thatcher", "\"Quanto maior o artista, maiores são os momentos de dúvida. Confiança inabalável é algo garantido para os menos talentosos, como um prêmio de consolação\" - Robert Hughes", "\"Seja feliz com o que você tem, mas fique animado com a chance de ter mais\" – Alan Cohen", "\"Somos nós que forjamos as correntes que usamos em nossas vidas\" – Charles Dickens", "\"Em nossas vidas, a mudança é inevitável. A perda é inevitável. A felicidade reside na nossa adaptabilidade em sobreviver a tudo de ruim\" – Buda", "\"Para cuidar de si mesmo, use a cabeça. Para cuidar dos outros, use seu coração\" – Eleanor Roosevelt","\"Sempre lembre que você é mais corajoso do que pensa, mais forte do que parece e mais esperto do que acredita\". – Christopher Robin", "\"Se você quer vencer, não fique olhando a escada. Comece a subir, degrau por degrau, até chegar ao topo.\" - Desconhecido",
		"\"Seu tempo é curto. Por isso, não o desperdice vivendo a vida de outra pessoa\" – Steve Jobs", "\"Procure suas qualidades, acredite em você, não fique pensando que os outros sabem mais que você. Acredite em seu poder.\" - Zibia"] ;*/

    private int _i;
    private int i;
    private GameObject msg;
    private Text text;
    private string[] msgs = {"\"Você provavelmente terá de entrar em uma batalha mais de uma vez para vencê-la\" -Margaret Thatcher", "\"Quanto maior o artista, maiores são os momentos de dúvida. Confiança inabalável é algo garantido para os menos talentosos, como um prêmio de consolação\" - Robert Hughes", "\"Seja feliz com o que você tem, mas fique animado com a chance de ter mais\" – Alan Cohen", "\"Somos nós que forjamos as correntes que usamos em nossas vidas\" – Charles Dickens", "\"Em nossas vidas, a mudança é inevitável. A perda é inevitável. A felicidade reside na nossa adaptabilidade em sobreviver a tudo de ruim\" – Buda", "\"Para cuidar de si mesmo, use a cabeça. Para cuidar dos outros, use seu coração\" – Eleanor Roosevelt","\"Sempre lembre que você é mais corajoso do que pensa, mais forte do que parece e mais esperto do que acredita\". – Christopher Robin", "\"Se você quer vencer, não fique olhando a escada. Comece a subir, degrau por degrau, até chegar ao topo.\" - Desconhecido",
		"\"Seu tempo é curto. Por isso, não o desperdice vivendo a vida de outra pessoa\" – Steve Jobs", "\"Procure suas qualidades, acredite em você, não fique pensando que os outros sabem mais que você. Acredite em seu poder.\" - Zibia"};
    private float cooldown;
    private float transDuration;
    private float minColor;
    private float r;
    private float g;
    private float b;
    private int len;
    private Color col;
    // Use this for initialization
    void Start () {
        msg = GameObject.Find("Message");
        text = msg.GetComponent<Text>();
        cooldown = 7.0f;
        transDuration = 1.5f;
        minColor = 0.5f;
        len = msgs.Length;
        
        
        
        if(IntroAnim.IsAppOpening()) {
            StartCoroutine(StartMessages());
        } else {
            SwitchMessage();
        }
    }

    private IEnumerator StartMessages() {
        _i = Random.Range(0, len);
        do{
            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);

        } while (r + g + b < minColor);
        col = new Color(r, g, b, 1f);
        text.color = col;
        text.text = msgs[_i];
        yield return new WaitForSeconds(9.0f);
        SwitchMessage();
    }

    public void SwitchMessage() {
        StartCoroutine(SwitchMessageCoroutine());
    }

    private  IEnumerator SwitchMessageCoroutine() {
        yield return new WaitForSeconds(cooldown);
        text.CrossFadeAlpha(0f, transDuration/2f, false);
        yield return new WaitForSeconds(transDuration/2f);
        do{
            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);

        } while (r + g + b < minColor);
        col = new Color(r, g, b, 1f);
        text.color = col;
        do {
            i = Random.Range(0, len);
        } while(i == _i);
        _i = i;
        text.text = msgs[i];
        text.CrossFadeAlpha(1f, transDuration/2f, false);
        yield return new WaitForSeconds(transDuration/2f);
        SwitchMessage();
    }
}
