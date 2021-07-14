using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakableCube : MonoBehaviour, IBreakable {
    [HideInInspector] public bool iHaveDoor;
    [SerializeField] GameObject door;
    [SerializeField] GameObject powerUp;
    [HideInInspector] public UnityEvent spawnDoor;
    int iHavePowerUp;
    
    void Awake(){
        if(spawnDoor == null)
            spawnDoor = new UnityEvent();

        iHavePowerUp = Random.Range(1, 10);
    }

    public void Break(){
        if(iHaveDoor){
            GameObject doorInstance = Instantiate(door, transform.position, Quaternion.identity);
            doorInstance.GetComponent<Door>().isDoorOpen = true;
            spawnDoor.Invoke();
        }
        if(iHavePowerUp == 1){
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
