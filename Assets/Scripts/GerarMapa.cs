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
    private GameObject enemy1;
	private GameObject choco;

    //Enemy1 values
    private float enemy1_minY;
    private float enemy1_maxY;
    private float enemy1_spawnPadding;
    private float enemy1_spawnDelay;
    private float enemy1_spawnRepeat;


	//Valores consumivel

	private float cons_spawnDelay;
	private float cons_spawnRepeat;
    
    // Use this for initialization
    void Start()
    {
		
        groundY = Chao.transform.position.y;
        Chao.transform.position = new Vector3(Chao.transform.position.x, groundY, Chao.transform.position.z);
        Chao2.transform.position = new Vector3(Chao2.transform.position.x, groundY, Chao2.transform.position.z);
		//spawn do inimigo
        enemy1 = Resources.Load<GameObject>("Prefabs/enemy1");
        enemy1_spawnPadding = 0f;
        enemy1_minY = groundY + Chao.transform.localScale.y / 2 + enemy1.transform.localScale.y / 2 + enemy1_spawnPadding;
        enemy1_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - enemy1.transform.localScale.y / 2 - enemy1_spawnPadding;
        enemy1_spawnDelay = 3f;
        enemy1_spawnRepeat = 1.5f;

        InvokeRepeating("SpawnEnemy1", enemy1_spawnDelay, enemy1_spawnRepeat);

		//spawn consumivel
		choco = Resources.Load<GameObject>("Prefabs/choco");

		cons_spawnDelay = 3f;
		cons_spawnRepeat = 10f;

		InvokeRepeating("SpawnCons", cons_spawnDelay, cons_spawnRepeat);

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

    void SpawnEnemy1() {
        Instantiate(enemy1, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(enemy1_minY, enemy1_maxY), 0f), Quaternion.identity);
    }

	void SpawnCons() {
		Instantiate(choco, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(enemy1_minY, enemy1_maxY), 0f), Quaternion.identity);
	}
}


