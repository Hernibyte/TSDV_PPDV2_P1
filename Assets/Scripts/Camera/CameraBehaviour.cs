using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    [SerializeField] float distance;
    [SerializeField] float ratio;
    GameObject target;
    void Start(){
        Player temp = FindObjectOfType<Player>();
        target = temp.gameObject;
    }

    void Update(){
        Vector3 targetPosition = target.gameObject.transform.position;

        transform.position = new Vector3(targetPosition.x, targetPosition.y + distance, targetPosition.z - ratio);
        transform.LookAt(target.gameObject.transform, Vector3.up);
    }
}
