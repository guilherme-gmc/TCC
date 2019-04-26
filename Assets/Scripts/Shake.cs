using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private float _shakeAmt;
    private float _shakeDuration;
    private bool _retainPos;
    public bool shaking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shaking) {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * _shakeAmt);
            newPos.z = transform.position.z;

            transform.position += newPos;
        }
    }

    public IEnumerator ShakeMe(float shakeAmt = 3f, float shakeDuration = 0.1f, bool retainPos = true) {
        _shakeAmt = shakeAmt;
        _shakeDuration = shakeDuration;
        _retainPos = retainPos;
        yield return StartCoroutine("ShakeCoroutine");
    }

    private IEnumerator ShakeCoroutine() {

        Vector3 originalPos = transform.position;

        if(!shaking) {
            shaking = true;
        }

        yield return new WaitForSeconds(_shakeDuration);

        shaking = false;
        if(_retainPos) {
            transform.position = originalPos;
        }
    }
}
