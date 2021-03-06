using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] WorldGenerator worldGenerator;
    [HideInInspector] public int gamePoints = 0;
    [HideInInspector] public int enemyDestroyed = 0;
    int enemyCount;
    bool gamePause;

    void Start(){
        worldGenerator.cubeWithDoor.GetComponent<BreakableCube>().spawnDoor.AddListener(SearchDoor);
        worldGenerator.playerInstance.GetComponent<Player>().imDie.AddListener(LoseGame);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            GamePause();
        }
    }

    public void GamePause(){
        gamePause = !gamePause;

        if(gamePause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
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
            if(worldGenerator.cubeWithDoor != null){
                worldGenerator.cubeWithDoor.GetComponent<BreakableCube>().Break();
                FindObjectOfType<Door>().isDoorOpen = true;
            }
            else
                FindObjectOfType<Door>().isDoorOpen = true;
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
