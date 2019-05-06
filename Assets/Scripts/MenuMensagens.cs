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
    private Button btnPrev;
    private Button btnNext;
    private Text msgText;
    private Text btnPrevText;
    private Text btnNextText;
    private string[] msgs = {"\"Você provavelmente terá de entrar em uma batalha mais de uma vez para vencê-la\" -Margaret Thatcher", "\"Quanto maior o artista, maiores são os momentos de dúvida. Confiança inabalável é algo garantido para os menos talentosos, como um prêmio de consolação\" - Robert Hughes", "\"Seja feliz com o que você tem, mas fique animado com a chance de ter mais\" – Alan Cohen", "\"Somos nós que forjamos as correntes que usamos em nossas vidas\" – Charles Dickens", "\"Em nossas vidas, a mudança é inevitável. A perda é inevitável. A felicidade reside na nossa adaptabilidade em sobreviver a tudo de ruim\" – Buda", "\"Para cuidar de si mesmo, use a cabeça. Para cuidar dos outros, use seu coração\" – Eleanor Roosevelt","\"Sempre lembre que você é mais corajoso do que pensa, mais forte do que parece e mais esperto do que acredita\". – Christopher Robin", "\"Se você quer vencer, não fique olhando a escada. Comece a subir, degrau por degrau, até chegar ao topo.\" - Desconhecido",
		"\"Seu tempo é curto. Por isso, não o desperdice vivendo a vida de outra pessoa\" – Steve Jobs", "\"Procure suas qualidades, acredite em você, não fique pensando que os outros sabem mais que você. Acredite em seu poder.\" - Zibia"};
    private float cooldown;
    private float transDuration;
    private float minColor;
    private float colorPadding;
    private float r;
    private float g;
    private float b;
    private int len;
    private Color col;
    private ColorBlock cb;
    private Coroutine currentMessage;

    void Start () {
        msg = GameObject.Find("Message");
        btnPrev = transform.Find("PreviousBtn").GetComponent<Button>();
        btnNext = transform.Find("NextBtn").GetComponent<Button>();
        msgText = msg.GetComponent<Text>();
        btnPrevText = transform.Find("PreviousBtn").transform.Find("Text").GetComponent<Text>();
        btnNextText = transform.Find("NextBtn").transform.Find("Text").GetComponent<Text>();
        cooldown = 7.0f;
        transDuration = 1.5f;
        minColor = 0.5f;
        colorPadding = 0.15f;
        len = msgs.Length;
        _i = 0;
        currentMessage = null;
        cb = btnPrev.colors;
        
        
        
        if(IntroAnim.IsAppOpening()) {
            StartCoroutine(StartMessages());
        } else {
            SwitchMessage();
        }
    }

    private IEnumerator StartMessages() {
        do{
            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);

        } while (r + g + b < minColor);

        col = new Color(r, g, b, 1f);
        msgText.color = col;
        cb.normalColor = col;
        cb.highlightedColor = new Color(r + colorPadding%1f, g + colorPadding%1f, b + colorPadding%1f, 1f);
        if(r - colorPadding < 0f) {
            r = 0f;
        } else {
            r -= colorPadding;
        }
        if(g - colorPadding < 0f) {
            g = 0f;
        } else {
            g -= colorPadding;
        }
        if(b - colorPadding < 0f) {
            b = 0f;
        } else {
            b -= colorPadding;
        }
        cb.pressedColor = new Color(r, g, b, 1f);
        btnPrev.colors = cb;
        btnNext.colors = cb;
        btnPrevText.color = new Color(1f - col.r, 1f - col.g, 1f - col.b, 1f);
        btnNextText.color = new Color(1f - col.r, 1f - col.g, 1f - col.b, 1f);
        msgText.text = msgs[_i];
        yield return new WaitForSeconds(9.0f);
        SwitchMessage();
    }

    public void SwitchMessage(string button = null) {
        StopAllCoroutines();
        currentMessage = StartCoroutine(SwitchMessageCoroutine(button));
    }

    private  IEnumerator SwitchMessageCoroutine(string button) {
        if(button == null) {
            yield return new WaitForSeconds(cooldown);

        }
        msgText.CrossFadeAlpha(0f, transDuration/2f, false);
        yield return new WaitForSeconds(transDuration/2f);
        do{
            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);

        } while (r + g + b < minColor);

        col = new Color(r, g, b, 1f);
        msgText.color = col;
        cb.normalColor = col;
        cb.highlightedColor = new Color(r + colorPadding%1f, g + colorPadding%1f, b + colorPadding%1f, 1f);
        if(r - colorPadding < 0f) {
            r = 0f;
        } else {
            r -= colorPadding;
        }
        if(g - colorPadding < 0f) {
            g = 0f;
        } else {
            g -= colorPadding;
        }
        if(b - colorPadding < 0f) {
            b = 0f;
        } else {
            b -= colorPadding;
        }
        cb.pressedColor = new Color(r, g, b, 1f);
        btnPrev.colors = cb;
        btnNext.colors = cb;
        btnPrevText.color = new Color(1f - col.r, 1f - col.g, 1f - col.b, 1f);
        btnNextText.color = new Color(1f - col.r, 1f - col.g, 1f - col.b, 1f);

        if(button == null) {
            do {
                i = Random.Range(0, len);
            } while(i == _i);
        } else if(button == "previous") {
            if(i == 0) {
                i = len-1;
            } else {
                i--;
            }
        } else if(button == "next") {
            i = (i+1)%len;
            print(i);
        }
        _i = i;
        msgText.text = msgs[i];
        msgText.CrossFadeAlpha(1f, transDuration/2f, false);
        yield return new WaitForSeconds(transDuration/2f);
        SwitchMessage();
    }

    public void MuteAudioToggle() {
        print("toggled");
    }





}
