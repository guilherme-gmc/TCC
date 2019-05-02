using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float lifespan = 1.5f;
    private float colliderLifespan = 1.2f;
    void Start()
    {
        StartCoroutine("Lifespan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Lifespan() {
        yield return new WaitForSeconds(colliderLifespan);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(lifespan - colliderLifespan);
        Destroy(this.gameObject);
    }
}
