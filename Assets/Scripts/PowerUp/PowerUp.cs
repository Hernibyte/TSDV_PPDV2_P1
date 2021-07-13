using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    int powerUpType = 0;
    [SerializeField] LayerMask playerLayerMask;

    void Awake(){
        powerUpType = Random.Range(1, 3);
    }

    void OnTriggerEnter(Collider other){
        if(Contains(playerLayerMask, other.gameObject.layer)){
            IPowerUP powerUp = other.gameObject.GetComponent<IPowerUP>();
            powerUp.ApplyPowerUp(powerUpType);
            Destroy(this.gameObject);
        }
    }

    bool Contains(LayerMask mask, int layer){
        return mask == (mask | (1 << layer));
    }
}
