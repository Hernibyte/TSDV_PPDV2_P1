using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : MonoBehaviour, IHittable {
    [SerializeField] LayerMask enemyTarget;
    [HideInInspector] public UnityEvent imEnemyDie;
    //bool activeRandom = true;
    float timer;
    int random;
    int lifes = 1;

    void Start(){
        random = Random.Range(1, 4);
    }

    void Update(){
        timer += Time.deltaTime;

        if(timer >= 2f){
            random = Random.Range(1, 4);
            timer = 0f;
        }
        
        switch (random){
            case 1:
                transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime;
            break;
            case 2:
                transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime;
            break;
            case 3:
                transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            break;
            case 4:
                transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime;
            break;
        }
    }

    void OnCollisionStay(Collision other){
        IHittable hittabble = other.transform.GetComponent<IHittable>();
        if(Contains(enemyTarget, other.gameObject.layer)){
            hittabble.Hit();
            imEnemyDie.Invoke();
            Destroy(this.gameObject);
        }
    }

    public void Hit(){
        lifes--;
        if(lifes <= 0){
            imEnemyDie.Invoke();
            Destroy(this.gameObject);
        }
    }

    bool Contains(LayerMask mask, int layer){
        return mask == (mask | (1 << layer));
    }
}
