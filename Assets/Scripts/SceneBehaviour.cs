using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour {
    static SceneBehaviour instance = null;

    public static SceneBehaviour Get {
        get{
            return instance;
        }
    }

    void Awake(){
        if(instance != null){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame(){
        Application.Quit();
    }

    public static void StaticLoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
