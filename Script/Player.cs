using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    CharacterController controller;
    bool IsGrounded;
    Vector3 MyRotation;

    [SerializeField]
    float Speed, RotationSpeed, MinY, MaxY;

    [Space]
    [SerializeField]
    GameObject Gun;

    [SerializeField]
    Transform AmmoPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = Gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        PlayerMovement();

        PlayerRotation();

        //OldAnimation();
    }


    void PlayerMovement()
    {
        float Haxis = Input.GetAxis("Horizontal");
        float Vaxis = Input.GetAxis("Vertical");
        var Movement = (Haxis * transform.right) + (Vaxis * transform.forward);
        Movement = Movement.normalized * Speed;

        NewAnimation(Vaxis);

        // For Gravity Check :--
        IsGrounded = controller.isGrounded;

        if (!IsGrounded)
        {
            Movement.y += Physics.gravity.y;
        }

        controller.Move(Movement * Time.deltaTime);
    }

    void PlayerRotation()
    {
        /*MouseX += Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        MouseY += Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        //transform.Rotate(0, MouseX, 0);

        MouseY = Mathf.Clamp(MouseY, MinY, MaxY);

        transform.rotation = Quaternion.Euler(-MouseY, MouseX, 0);
        //transform.GetChild(0).transform.Rotate(-MouseY, 0, 0);*/

        var MouseX = Input.GetAxis("Mouse X") /** RotationSpeed * Time.deltaTime*/;
        var MouseY = Input.GetAxis("Mouse Y") /** RotationSpeed * Time.deltaTime*/;
        MyRotation.x += MouseX;
        MyRotation.y += MouseY;
        MyRotation.y = Mathf.Clamp(MyRotation.y, MinY, MaxY);
        transform.eulerAngles = new Vector2(-MyRotation.y, MyRotation.x);
    }

    /*void OldAnimation()
    {
        // For Walk And Run ::--
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Run", true);
        }
        else
        {
            //animator.SetBool("Aim", false);
            animator.SetBool("Run", false);
        }

        // For Reload Gun ::--
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Reload", true);
        }
        else
        {
            animator.SetBool("Reload", false);
        }

        // For Take A Aim ::--
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("Aim", true);
        }
        else
        {
            animator.SetBool("Aim", false);
        }
    }*/

    void NewAnimation(float Vaxis)
    {

        animator.SetFloat("Run", Vaxis);

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Reload", true);
        }
        else
        {
            animator.SetBool("Reload", false);
        }

        // For Take A Aim ::--
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("Aim", true);
        }
        else
        {
            animator.SetBool("Aim", false);
        }
    }

}

