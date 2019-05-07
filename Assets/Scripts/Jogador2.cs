using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Jogador2 : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private float spd = 140f * g.spdMult;
    private Vector2 dir = Vector2.zero;
    private bool attacking;
    private GameObject bullet;

    private SceneTransitions sceneTrans;

    // Use this for initialization
    void Start() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sceneTrans = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
        bullet = Resources.Load<GameObject>("Prefabs/bullet");

    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneTransitions.transitioning && !PauseHandler.estaPausado)
        {
            //return anim
            anim.speed = 1;

            if(Input.GetButtonDown("Right")) {
                dir.x += 1;
            }
            if(Input.GetButtonUp("Right")) {
                dir.x = 0;
            }
            if(Input.GetButtonDown("Up")) {
                dir.y += 1;
            }
            if(Input.GetButtonUp("Up")) {
                dir.y = 0;
            }
            if(Input.GetButtonDown("Left")) {
                dir.x -= 1;
            }
            if(Input.GetButtonUp("Left")) {
                dir.x = 0;
            }
            if(Input.GetButtonDown("Down")) {
                dir.y -= 1;
            }
            if(Input.GetButtonUp("Down")) {
                dir.y = 0;
            }

            //Attack
            if(Input.GetButtonDown("Fire")) {
                if(!attacking) {
                    StartCoroutine("Attack");
                }
            }
            
            body.velocity = dir * spd * Time.deltaTime;
        } else
        {
            anim.speed = 0;
            body.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser") {
            sceneTrans.ChangeScene("gameOver");
        }
    }

    private IEnumerator Attack() {
        attacking = true;
        Instantiate(bullet, new Vector3(transform.position.x + transform.localScale.x / 4, transform.position.y, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        attacking = false;
    }

}
