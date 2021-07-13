using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour {
    public int distanceToExplosion = 2;
    [HideInInspector] public UnityEvent imExplode;

    void Start(){
        if(imExplode == null) 
            imExplode = new UnityEvent();

        Reposition();
        StartCoroutine(Explosion());
    }

    void Reposition(){
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z)
        );
    }

    IEnumerator Explosion(){
        yield return new WaitForSeconds(2f);

        Vector3 ExplosionPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        bool endCheck = false;
        for(int i = 0; i < distanceToExplosion; i++){
            ExplosionPosition.x -= 1;
            
            ExplosionChecking(ExplosionPosition, ref endCheck);

            if(endCheck)
                break;
        }

        ExplosionPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        endCheck = false;
        for(int i = 0; i < distanceToExplosion; i++){
            ExplosionPosition.x += 1;
            
            ExplosionChecking(ExplosionPosition, ref endCheck);

            if(endCheck)
                break;
        }

        ExplosionPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        endCheck = false;
        for(int i = 0; i < distanceToExplosion; i++){
            ExplosionPosition.z -= 1;

            ExplosionChecking(ExplosionPosition, ref endCheck);

            if(endCheck)
                break;
        }

        ExplosionPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        endCheck = false;
        for(int i = 0; i < distanceToExplosion; i++){
            ExplosionPosition.z += 1;
            
            ExplosionChecking(ExplosionPosition, ref endCheck);

            if(endCheck)
                break;
        }

        imExplode.Invoke();

        Destroy(this.gameObject);

        yield return null;
    }

    void ExplosionChecking(Vector3 position, ref bool check){
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        foreach(Collider collider in colliders){
            IBreakable breakable = collider.GetComponent<IBreakable>();
            IHittable hittable = collider.GetComponent<IHittable>();
            if(breakable != null){
                check = true;
                breakable.Break();
            }
            else if(hittable != null){
                hittable.Hit();
            }
            else
                check = true;
        }
    }
}
