using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldGenerator : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject unbreakableCube;
    [SerializeField] GameObject breakableCube;
    [SerializeField] int horizontalSize;
    [SerializeField] int verticalSize;
    [SerializeField] int randomRange = 3;
    [SerializeField] int randomEnemyRange = 20;
    [HideInInspector] public GameObject cubeWithDoor;
    [HideInInspector] public GameObject playerInstance;
    bool cubeWithDoorActivated = false;
    GameObject cubeTemporally;
    float positionX = 0;
    float positionZ = 0;

    void Awake() {
        for(int i = 1; i <= horizontalSize; i++){
            for(int j = 1; j <= verticalSize; j++){
                int rand = Random.Range(1, randomRange);
                int enemyRand = Random.Range(1, randomEnemyRange);

                if(i == 1 || j == 1){
                    cubeTemporally = Instantiate(unbreakableCube, new Vector3(positionX, 0f, positionZ), Quaternion.identity, transform);
                }
                else if(i == horizontalSize || j == verticalSize) {
                    cubeTemporally = Instantiate(unbreakableCube, new Vector3(positionX, 0f, positionZ), Quaternion.identity, transform);
                }
                else if(i % 2 == 1 && j % 2 == 1){
                    cubeTemporally = Instantiate(unbreakableCube, new Vector3(positionX, 0f, positionZ), Quaternion.identity, transform);
                }
                else if(i == (horizontalSize-1) && j == (verticalSize-1)){
                    playerInstance = Instantiate(player, new Vector3(positionX, 0f, positionZ), Quaternion.identity);
                }
                else if(i == (horizontalSize-2) && j == (verticalSize-1) || i == (horizontalSize-1) && j == (verticalSize-2)){
                    //safe zone
                }
                else{
                    if(rand == 1){
                        if(!cubeWithDoorActivated){
                            cubeWithDoor = Instantiate(breakableCube, new Vector3(positionX, 0f, positionZ), Quaternion.identity, transform);
                            cubeWithDoor.GetComponent<BreakableCube>().iHaveDoor = true;
                            cubeWithDoorActivated = true;
                        }
                        else
                            cubeTemporally = Instantiate(breakableCube, new Vector3(positionX, 0f, positionZ), Quaternion.identity, transform);
                    }
                    else if(enemyRand == 1){
                        GameObject EnemyInstance = Instantiate(enemy1, new Vector3(positionX, 0f, positionZ), Quaternion.identity);
                        EnemyInstance.GetComponent<EnemyBehaviour>().imEnemyDie.AddListener(CallEnemyDieEvent);
                        FindObjectOfType<GameManager>().IfEnemySpawn();
                    }
                    else if(enemyRand == 2){
                        GameObject EnemyInstance = Instantiate(enemy2, new Vector3(positionX, 0f, positionZ), Quaternion.identity);
                        EnemyInstance.GetComponent<EnemyBehaviour>().imEnemyDie.AddListener(CallEnemyDieEvent);
                        FindObjectOfType<GameManager>().IfEnemySpawn();
                    }
                }

                positionZ++;
            }
            positionZ = 0;
            positionX++;
        }
    }

    void CallEnemyDieEvent(){
        FindObjectOfType<GameManager>().IfEnemyDie();
    }
}
