using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarMapa : MonoBehaviour
{
    public GameObject Teto;
    public GameObject Chao;

    public GameObject player;

    private float groundY;
    private GameObject enemy;
    private GameObject consumable;

    //enemy values
    private float enemy_minY;
    private float enemy_maxY;
    private float enemy_spawnPadding;
    private float enemy_spawnDelay;
    private float enemy_spawnRepeat;

    //consumable values
    private float consumable_minY;
    private float consumable_maxY;
    private float consumable_spawnPadding;
    private float consumable_spawnDelay;
    private float consumable_spawnRepeat;
    
    // Use this for initialization
    void Start()
    {
		//Ambient
        groundY = Chao.transform.position.y;      

        if(SceneTransitions._context == "gameCont" && Boss.lost) {
            consumable = Resources.Load<GameObject>("Prefabs/flower");
            enemy = Resources.Load<GameObject>("Prefabs/Enemy1");
        } else {
            consumable = Resources.Load<GameObject>("Prefabs/choco");
		    enemy = Resources.Load<GameObject>("Prefabs/Enemy1");
        }
        //enemy
        enemy_spawnPadding = 0.2f;
		enemy_minY = groundY + Chao.transform.localScale.y / 2 + enemy.transform.localScale.y / 2 + enemy_spawnPadding;
        enemy_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - enemy.transform.localScale.y / 2 - enemy_spawnPadding;
        enemy_spawnDelay = 0.5f;
        enemy_spawnRepeat = 1f;

        //Consumable
        consumable_spawnPadding = 0f;
        consumable_minY = groundY + Chao.transform.localScale.y / 2 + consumable.transform.localScale.y / 2 + consumable_spawnPadding;
        consumable_maxY = Teto.transform.position.y - Teto.transform.localScale.y / 2 - consumable.transform.localScale.y / 2 - consumable_spawnPadding;
        consumable_spawnDelay = 2f;
        consumable_spawnRepeat = enemy_spawnRepeat*3;


        InvokeRepeating("SpawnEnemy", enemy_spawnDelay, enemy_spawnRepeat);
        InvokeRepeating("SpawnConsumable", consumable_spawnDelay, consumable_spawnRepeat);
    }

    void SpawnEnemy() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            Instantiate(enemy, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(enemy_minY, enemy_maxY), 0f), Quaternion.identity);
        }
    }

    void SpawnConsumable() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            Instantiate(consumable, new Vector3(Camera.main.gameObject.transform.position.x + Camera.main.orthographicSize * 2, Random.Range(consumable_minY, consumable_maxY), 0f), Quaternion.identity);
        }
    }

}
