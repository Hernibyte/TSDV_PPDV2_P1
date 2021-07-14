using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
    [HideInInspector] public UnityEvent openDoor;
    [SerializeField] LayerMask playerLayerMask;
    public bool isDoorOpen = false;

    void Awake(){
        if(openDoor == null)
            openDoor = new UnityEvent();
    }

    void OnTriggerEnter(Collider other){
        if(isDoorOpen){
            if(Contains(playerLayerMask, other.gameObject.layer))
                openDoor.Invoke();
        }
    }

    bool Contains(LayerMask mask, int layer){
        return mask == (mask | (1 << layer));
    }
}
