using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarMapa : MonoBehaviour
{
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

        //Enemy1
		enemy1 = Resources.Load<GameObject>("Prefabs/Enemy1");
        enemy1_spawnPadding = 0.2f;
		enemy1_minY = groundY + Chao.transform.localScale.y / 2 + enemy1.transform.localScale.y / 2 + enemy1_spawnPadding;
        enemy1_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - enemy1.transform.localScale.y / 2 - enemy1_spawnPadding;
        enemy1_spawnDelay = 0.5f;
        enemy1_spawnRepeat = 1f;

        //Choco
        choco = Resources.Load<GameObject>("Prefabs/choco");
        choco_spawnPadding = 0f;
        choco_minY = groundY + Chao.transform.localScale.y / 2 + choco.transform.localScale.y / 2 + choco_spawnPadding;
        choco_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - choco.transform.localScale.y / 2 - choco_spawnPadding;
        choco_spawnDelay = 2f;
        choco_spawnRepeat = enemy1_spawnRepeat*3;


        InvokeRepeating("SpawnEnemy1", enemy1_spawnDelay, enemy1_spawnRepeat);
        InvokeRepeating("SpawnChoco", choco_spawnDelay, choco_spawnRepeat);
    }

    void SpawnEnemy1() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            Instantiate(enemy1, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(enemy1_minY, enemy1_maxY), 0f), Quaternion.identity);
        }
    }

    void SpawnChoco() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            Instantiate(choco, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(choco_minY, choco_maxY), 0f), Quaternion.identity);
        }
    }

}
