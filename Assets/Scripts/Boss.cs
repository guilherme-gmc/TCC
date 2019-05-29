using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D body;
    protected float currentHp;
    protected float hp1;
    protected float hp2;
    public static int phase = 1;
    private Coroutine attack1;
    private Coroutine attack2;
    protected float startingCooldown;
    protected float endingCooldown;
    private float bulletRepeat;
    private GameObject laser;
    private GameObject lastLaser;
    private int lastLaserPos = 0;
    private int laserPos = 0;
    private GameObject bossBullet;
    private Shake shake;
    private bool switching;
    private float phase2WlkSpd;
    Vector2 vspd;
    private Vector3 scaleDec;
    private bool attacking2;
    private SceneTransitions sceneTrans;
    private Animator anim;
    private CapsuleCollider2D coll;
    private Health health;
    public static bool lost = false;

    void Start()
    {
        laser = Resources.Load<GameObject>("Prefabs/laser");
        bossBullet = Resources.Load<GameObject>("Prefabs/BossBullet");
        sceneTrans = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        shake = GetComponent<Shake>();
        health = GameObject.Find("Health").GetComponent<Health>();
        hp1 = 100f;
        hp2 = 200f;
        currentHp = hp1;
        startingCooldown = 3f;
        endingCooldown = 1.8f;
        bulletRepeat = 0.35f;
        scaleDec = new Vector3((transform.localScale.x - 1.45f)/3f, (transform.localScale.y - 1.55f)/3f, 0f);
        phase2WlkSpd = 140f;
        vspd = new Vector2(0f, phase2WlkSpd);

        if(phase == 1) {
            StartAttack1();
            anim.SetTrigger("phaseOne");
        } else {
            transform.localScale = new Vector3(1.45f, 1.55f, transform.localScale.z);
            transform.position = new Vector3(7.1f, transform.position.y, transform.position.y);
            coll.offset = new Vector2(-0.05f, 0f);
            coll.size = new Vector2(1.1f, 1.55f);
            anim.SetTrigger("phaseTwo");
            currentHp = hp2;
            //attacking2 = true;
            body.velocity = vspd * Time.deltaTime;
            StartAttack2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneTransitions.transitioning && !PauseHandler.estaPausado) {
            if(switching) {
                /*if(transform.localScale.x > 1.45f) {
                    transform.localScale -= scaleDec * Time.deltaTime;
                    //transform.position += new Vector3(scaleDec.x/2, 0f, 0f) * Time.deltaTime;
                }*/

                if(!shake.shaking) {
                    switching = false;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage() {
        if(!switching) {
            if(currentHp - g.bulletDmg <= 0f) {
                currentHp = 0f;
                if(phase == 1) {
                    SwitchPhase();
                } else {
                    Die();
                }
            } else {
                shake.ShakeMe();
                currentHp -= g.bulletDmg;
            }
            print("Phase " + phase + ": " + currentHp + "HP");
        }
    }

    private void Die() {
        StartCoroutine(DieCoroutine());

    }

    private IEnumerator DieCoroutine() {
        StopCoroutine(attack2);
        //attacking2 = false;
        body.velocity = Vector2.zero;
        yield return shake.ShakeMe(4f, 3f, true);
        Destroy(this.gameObject);
        sceneTrans.ChangeScene("gameOver");
    }

    //phase 1 laser attack
    private void StartAttack1() {
        attack1 = StartCoroutine("Attack1");
    }

    private IEnumerator Attack1() {
        yield return new WaitForSeconds((currentHp / 100) * (startingCooldown - endingCooldown) + endingCooldown);
        if(!switching && !PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            lastLaser = Instantiate(laser, new Vector3(transform.position.x - transform.localScale.x - 2f, GenerateAttackPos(), 0f), Quaternion.identity);
            lastLaser.transform.SetParent(this.transform, true);
            StartAttack1();
        }
    }

    //current phase 2 bullet attack
    private void StartAttack2() {
        attack2 = StartCoroutine("Attack2");
    }

    private IEnumerator Attack2() {
        yield return new WaitForSeconds((currentHp / 100) * (startingCooldown - endingCooldown) + endingCooldown);
        int shots = Random.Range(3, 7); //3 a 6 tiros (min inclusivo, max exclusivo)
        for(int i = 0; i < shots; i++) {
            if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
                Instantiate(bossBullet, new Vector3(transform.position.x - transform.localScale.x, transform.position.y, 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(bulletRepeat);
        }
        StartAttack2();
    }

    //Abandoned phase 2 laser attack
    /*private IEnumerator Wait() {
        yield return StartCoroutine(WaitCoroutine(true));
        if(!SceneTransitions.transitioning) {
            lastLaser = Instantiate(laser, new Vector3(transform.position.x - transform.localScale.x / 2 - 0.3f, transform.position.y, 0f), Quaternion.identity);
            lastLaser.transform.parent = this.gameObject.transform;
            yield return StartCoroutine(WaitCoroutine(false));
        }
    }

    private IEnumerator WaitCoroutine(bool beforeLaser) {
        if(beforeLaser) {
            yield return new WaitForSeconds(Laser.lifespan);
        } else {
            yield return new WaitForSeconds(Laser.lifespan * 2);
        }
    }*/

    private float GenerateAttackPos() {
        do {
            laserPos = (int) Mathf.Floor(Random.Range(-1.0f, 2f));
        } while(laserPos == lastLaserPos);

        lastLaserPos = laserPos;

        return laserPos * 2.65f;
    }

    private void SwitchPhase() {
        StopCoroutine(attack1);
        StartCoroutine(SwitchCoroutine());
    }

    private IEnumerator SwitchCoroutine() {
        switching = true;
        lost = true;
        if(lastLaser != null) {
            Destroy(lastLaser);
        }
        phase = 2;
        g.maxHp++;
        g.hp++;
        health.UpdateHealth();
        yield return shake.ShakeMe(2f, 3f);
        sceneTrans.ChangeScene("gameCont");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Roof") {
            body.velocity = -body.velocity;
        }
    }


}