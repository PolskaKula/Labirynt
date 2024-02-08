using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController; 
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprint = 1f;
    private Vector3 velocity;

    private bool groundedPlayer;
    private float jumpHeight = 2.0f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
        SprintManager();
        IntoTheVoid();
    }

    void PlayerMove() {
        RaycastHit hit;
        groundedPlayer = Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.2f, groundMask);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        characterController.Move(move * speed * Time.deltaTime * sprint);

        if (groundedPlayer) {
            if (velocity.y < 0) {
                velocity.y = 0f;
            }

            if (Input.GetButtonDown("Jump")) {
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * -9.81f);
            }

            string TerrainType = hit.collider.gameObject.tag;

            switch (TerrainType)
            {
                case "Low":
                    speed = 2f;
                    break;

                case "High":
                    speed = 10f;
                    break;

                default:
                    speed = 5f;
                    break;
            }
        }

        velocity.y += -9.81f * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void SprintManager()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 2f;
        }
        else
        {
            sprint = 1f;
        }
    }

    void IntoTheVoid()
    {
        if (transform.position.y < -10f) transform.position = new Vector3(0f, 3f, 0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
            hit.gameObject.GetComponent<Pickup>().PickedUp();
    }
}