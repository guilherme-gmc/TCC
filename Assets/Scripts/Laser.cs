using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float lifespan = 1.83f;
    private float colliderLifespan = 0.66f;
    private float colliderStart = 1f;
    private BoxCollider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        StartCoroutine("Lifespan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Lifespan() {
        coll.enabled = false;
        yield return new WaitForSeconds(colliderStart);
        coll.enabled = true;
        yield return new WaitForSeconds(colliderLifespan);
        coll.enabled = false;
        yield return new WaitForSeconds(lifespan - (colliderLifespan + colliderStart));
        Destroy(this.gameObject);
    }
}
