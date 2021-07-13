using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] WorldGenerator worldGenerator;
    [HideInInspector] public int gamePoints = 0;
    [HideInInspector] public int enemyDestroyed = 0;
    int enemyCount;

    void Start(){
        worldGenerator.cubeWithDoor.GetComponent<BreakableCube>().spawnDoor.AddListener(SearchDoor);
        worldGenerator.playerInstance.GetComponent<Player>().imDie.AddListener(LoseGame);
    }

    public void IfEnemySpawn(){
        enemyCount++;
    }

    public void IfEnemyDie(){
        enemyCount--;
        gamePoints += 100;
        enemyDestroyed++;
        IfAllEnemyDie();
    }

    public void IfAllEnemyDie(){
        if(enemyCount <= 0){
            worldGenerator.cubeWithDoor.GetComponent<BreakableCube>().Break();
        }
    }

    void SearchDoor(){
        FindObjectOfType<Door>().openDoor.AddListener(PassLevel);
    }

    void PassLevel(){
        SceneBehaviour.Get?.ChangeScene("PassedLevel");
    }

    void LoseGame(){
        SceneBehaviour.Get?.ChangeScene("Lose");
    }
}
