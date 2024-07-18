using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureMovement : MonoBehaviour
{
    Vector3 movement;
    CharacterController controller;
    public float moveSpeed;
    Vector3 myRotation;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myRotation = transform.eulerAngles;
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

        // Player Rotation
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        myRotation.x += mouseX;
        myRotation.y += mouseY;
        myRotation.y = Mathf.Clamp(myRotation.y, -30, 30);
        transform.eulerAngles = new Vector2(-myRotation.y, myRotation.x);

    }

}
