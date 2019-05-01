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

    //Choco values
    private float choco_minY;
    private float choco_maxY;
    private float choco_spawnPadding;
    private float choco_spawnDelay;
    private float choco_spawnRepeat;
    
    // Use this for initialization
    void Start()
    {
		//Ambient
        groundY = Chao.transform.position.y;
        Chao.transform.position = new Vector3(Chao.transform.position.x, groundY, Chao.transform.position.z);
        Chao2.transform.position = new Vector3(Chao2.transform.position.x, groundY, Chao2.transform.position.z);
        

        //Enemy1
		enemy1 = Resources.Load<GameObject>("Prefabs/Enemy1");
        enemy1_spawnPadding = 0f;
		enemy1_minY = groundY + Chao.transform.localScale.y / 2 + enemy1.transform.localScale.y / 2 + enemy1_spawnPadding;
        enemy1_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - enemy1.transform.localScale.y / 2 - enemy1_spawnPadding;
        enemy1_spawnDelay = 3f;
        enemy1_spawnRepeat = 2f;
        InvokeRepeating("SpawnEnemy1", enemy1_spawnDelay, enemy1_spawnRepeat);

        //Choco
        choco = Resources.Load<GameObject>("Prefabs/choco");
        choco_spawnPadding = 0f;
        choco_minY = groundY + Chao.transform.localScale.y / 2 + choco.transform.localScale.y / 2 + choco_spawnPadding;
        choco_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - choco.transform.localScale.y / 2 - choco_spawnPadding;
        choco_spawnDelay = 10f;
        choco_spawnRepeat = 5f;
        InvokeRepeating("SpawnChoco", choco_spawnDelay, choco_spawnRepeat);
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
        if(!PauseHandler.estaPausado) {
            Instantiate(enemy1, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(enemy1_minY, enemy1_maxY), 0f), Quaternion.identity);
        }
    }

    void SpawnChoco() {
        if(!PauseHandler.estaPausado) {
            Instantiate(choco, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(choco_minY, choco_maxY), 0f), Quaternion.identity);
        }
    }

}
