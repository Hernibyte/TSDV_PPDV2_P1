using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IHittable, IPowerUP {
    [SerializeField] GameObject bomb;
    [HideInInspector] public UnityEvent imDie;
    public int lifes = 3;
    public int distanceToExplosionBomb = 2;
    public int bombCount = 1;

    void Awake() {
        if(imDie == null)
            imDie = new UnityEvent();
    }

    void Update() {
        GenerateBombs();
    }

    void GenerateBombs(){
        if(bombCount > 0){
            if(Input.GetKeyDown(KeyCode.Space)){
                GameObject instanceBomb = Instantiate(bomb, transform.position, Quaternion.identity);
                instanceBomb.GetComponent<Bomb>().distanceToExplosion = distanceToExplosionBomb;
                instanceBomb.GetComponent<Bomb>().imExplode.AddListener(RestoreBombs);
                bombCount--;
            }
        }
    }

    void RestoreBombs(){
        bombCount++;
    }

    public void Hit(){
        lifes--;
        IfIDie();
    }

    public void ApplyPowerUp(int powerUpType){
        switch(powerUpType){
            case 1:
                distanceToExplosionBomb++;
            break;
            case 2:
                bombCount++;
            break;
            case 3:
                lifes++;
            break;
        }
    }

    void IfIDie(){
        if(lifes <= 0)
            imDie.Invoke();
    }
}
