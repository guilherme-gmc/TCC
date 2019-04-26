using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float lifespan = 1.5f;
    void Start()
    {
        StartCoroutine("Lifespan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Lifespan() {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
