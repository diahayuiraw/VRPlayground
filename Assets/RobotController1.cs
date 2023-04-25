using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{


    CharacterController controller;

    public GameObject left_arm;

    public float movementSpeed = 1.0f;
    public float leaningAngle = 30.0f;

    private float lastAngle = 0;
    private int init = 100;

    [SerializeField]
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        lastAngle = transform.rotation.eulerAngles.y;

        controller = GetComponent<CharacterController>();

    }



    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        float gravity = -9.8f * Time.deltaTime;

        if (controller.isGrounded)
        {
            gravity = 0;
        }

        if (init-- > 0)
        {
            gravity = -9.8f * Time.deltaTime;
        }

        Vector3 movement = Vector3.zero;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(leaningAngle, targetAngle, 0.0f);

            movement = direction * movementSpeed * Time.deltaTime;
            movement.y = gravity;

            left_arm.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);

            lastAngle = targetAngle;

        }
        else
        {
            transform.rotation = Quaternion.Euler(0.0f, lastAngle, 0.0f);

            left_arm.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);

            movement.y = gravity;
        }

        controller.Move(movement);
        velocity = controller.velocity;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GemZone")
        {
            other.gameObject.SetActive(false);
        }
    }



}
