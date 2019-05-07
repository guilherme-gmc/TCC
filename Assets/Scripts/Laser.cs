using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float lifespan = 2.33f;
    private float colliderLifespan = 0.66f;
    private float colliderStart = 1.5f;
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
        coll.size = new Vector2(0.2f, coll.size.y);
        coll.offset = new Vector2(0f, 0f);
        yield return new WaitForSeconds(colliderStart);
        coll.size = new Vector2(5.035152f, coll.size.y);
        coll.offset = new Vector2(-1.414173f, 0.01922114f);
        yield return new WaitForSeconds(colliderLifespan);
        coll.size = new Vector2(0.2f, coll.size.y);
        coll.offset = new Vector2(0f, 0f);
        yield return new WaitForSeconds(lifespan - (colliderLifespan + colliderStart));
        Destroy(this.gameObject);
    }
}
