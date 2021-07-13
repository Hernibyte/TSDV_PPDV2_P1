using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float velocity;
    CharacterController controller;

    void Awake(){
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate(){
        Movement();
    }

    void Movement(){
        float axisX = Input.GetAxis("Horizontal") * velocity;
        float axisZ = Input.GetAxis("Vertical") * velocity;

        controller.Move(new Vector3(axisX, 0f, axisZ));
    }
}
