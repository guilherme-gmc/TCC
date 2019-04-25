using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador2 : MonoBehaviour
{
	float vel = 5f;

	 // Start is called before the first frame update
    void Start()
    {
		

    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float vely = Input.GetAxis("Vertical") * vel  * Time.deltaTime;
		float velx = Input.GetAxis("Horizontal") * vel * Time.deltaTime;
		transform.Translate(velx,vely,0);
    }
}
