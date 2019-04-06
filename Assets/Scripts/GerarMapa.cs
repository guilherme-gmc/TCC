using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarMapa : MonoBehaviour
{

    public GameObject Teto2;
    public GameObject Chao2;
    public GameObject Teto;
    public GameObject Chao;

    public GameObject player;

    private float groundY;

    // Use this for initialization
    void Start()
    {
        groundY = Chao.transform.position.y;
        Chao.transform.position = new Vector3(Chao.transform.position.x, groundY, Chao.transform.position.z);
        Chao2.transform.position = new Vector3(Chao2.transform.position.x, groundY, Chao2.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Chao2.transform.position.x + 20 < player.transform.position.x - 6)
        {
            Chao2.transform.position += new Vector3(80f, 0f, 0f);
            Teto2.transform.position += new Vector3(80f, 0f, 0f);
        }

        if (Chao.transform.position.x + 20 < player.transform.position.x - 6)
        {
            Chao.transform.position += new Vector3(80f, 0f, 0f);
            Teto.transform.position += new Vector3(80f, 0f, 0f);
        }

    }
}
