using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D body;
    protected float currentHp;
    protected float hp1;
    protected float hp2;
    private int phase;
    private Coroutine attack1;
    protected float startingCooldown;
    protected float endingCooldown;
    private GameObject laser;
    private GameObject lastLaser;
    private int lastLaserPos = 0;
    private int laserPos = 0;
    private Shake shake;
    private bool switching;
    private float phase2WlkSpd;
    Vector2 vspd;
    private Vector3 scaleDec;
    private bool attacking2;
    private bool doneAttacking2;
    float attackY;
    bool arrived;
    bool standing;
    private SceneTransitions sceneTrans;

    void Start()
    {
        laser = Resources.Load<GameObject>("Prefabs/laser");
        sceneTrans = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
        body = GetComponent<Rigidbody2D>();
        shake = GetComponent<Shake>();
        hp1 = 100f;
        hp2 = 200f;
        currentHp = hp1;
        phase = 1;
        startingCooldown = 3f;
        endingCooldown = 2f;
        scaleDec = new Vector3((transform.localScale.x - 1.45f)/3f, (transform.localScale.y - 1.55f)/3f, 0f);
        phase2WlkSpd = 140f;
        vspd = Vector2.zero;
        doneAttacking2 = true;
        arrived = false;
        standing = false;
        StartAttack1();
    }

    // Update is called once per frame
    void Update()
    {
        if(switching) {
            if(transform.localScale.x > 1.45f) {
                transform.localScale -= scaleDec * Time.deltaTime;
                //transform.position += new Vector3(scaleDec.x/2, 0f, 0f) * Time.deltaTime;
            }

            if(!shake.shaking) {
                switching = false;
            }
        }

        if(attacking2) {
            if(doneAttacking2) {
                doneAttacking2 = false;
                standing = false;
                attackY = GenerateAttackPos();
                arrived = false;
            }
            
            if(!arrived) {
                if(attackY > transform.position.y) {
                    vspd = new Vector2(0f, phase2WlkSpd);
                    if(transform.position.y + vspd.y * Mathf.Pow(Time.deltaTime, 2) > attackY) {
                        transform.position = new Vector3(transform.position.x, attackY, transform.position.z);
                        body.velocity = Vector2.zero;
                        arrived = true;
                    } else {
                        body.velocity = vspd * Time.deltaTime;
                        
                    }
                } else if(attackY < transform.position.y) {
                    vspd = new Vector2(0f, -phase2WlkSpd);
                    if(transform.position.y + vspd.y * Mathf.Pow(Time.deltaTime, 2) < attackY) {
                        transform.position = new Vector3(transform.position.x, attackY, transform.position.z);
                        body.velocity = Vector2.zero;
                        arrived = true;
                    } else {
                        body.velocity = vspd * Time.deltaTime;
                    }
                } else {
                    vspd = Vector2.zero;
                    arrived = true;
                }
            } else {
                if(!standing) {
                    StartCoroutine(Wait());
                    standing = true;
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
        attacking2 = false;
        body.velocity = Vector2.zero;
        yield return shake.ShakeMe(4f, 3f, true);
        Destroy(this.gameObject);
        sceneTrans.ChangeScene("gameOver");
    }

    private void StartAttack1() {
        attack1 = StartCoroutine("Attack1");
    }

    private IEnumerator Attack1() {
        yield return new WaitForSeconds((currentHp / 100) * (startingCooldown - endingCooldown) + endingCooldown);
        if(!switching) {
            lastLaser = Instantiate(laser, new Vector3(transform.position.x - transform.localScale.x / 2 - laser.transform.localScale.x / 2, GenerateAttackPos(), 0f), Quaternion.identity);
            lastLaser.transform.parent = this.gameObject.transform;
            StartAttack1();
        }
    }

    private IEnumerator Wait() {
        yield return StartCoroutine(WaitCoroutine(true));
        lastLaser = Instantiate(laser, new Vector3(transform.position.x - transform.localScale.x / 2 - laser.transform.localScale.x / 2, transform.position.y, 0f), Quaternion.identity);
        lastLaser.transform.parent = this.gameObject.transform;
        yield return StartCoroutine(WaitCoroutine(false));
    }

    private IEnumerator WaitCoroutine(bool beforeLaser) {
        if(beforeLaser) {
            yield return new WaitForSeconds(Laser.lifespan);
        } else {
            yield return new WaitForSeconds(Laser.lifespan * 2);
            doneAttacking2 = true;
        }
    }

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
        if(lastLaser != null) {
            Destroy(lastLaser);
        }
        currentHp = hp2;
        phase = 2;
        yield return shake.ShakeMe(2f, 3f);
        attacking2 = true;
    }


}
