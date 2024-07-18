using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{

    Vector3 movement;
    CharacterController controller;
    public float moveSpeed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Player Movement
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        movement = (hAxis * transform.right) + (vAxis * transform.forward);
        movement = movement.normalized * moveSpeed;
        controller.Move(movement * Time.deltaTime);

        anim.SetFloat("Walk", vAxis);

    }
}
