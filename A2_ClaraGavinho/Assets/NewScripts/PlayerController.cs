using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    private float _moveSpeed = 5f; //player speed
    [SerializeField]
    private float _gravity = -20f; //how strong is gravity when we jump
    [SerializeField]
    private float _rotationSpeed = 90f; //how quickly the player will turn
    [SerializeField]
    private float _jumpSpeed = 15f; //how fast the player will jump

    private float horizontalInput;
    private float verticalInput;

    public int health;
    public TextMeshProUGUI healthText;

    Vector3 moveVelocity; //forward velocity
    Vector3 turnVelocity; //rotate velocity
    Vector3 direction; //the direction we will go

    private CharacterController _controller;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = new Vector3(horizontalInput, 0, verticalInput); // WASD for direction
        direction.Normalize();//set vector magnitude to 1.0

        if (_controller.isGrounded) //must be on a surface to jump
        {
            moveVelocity = transform.forward * _moveSpeed * verticalInput;
            turnVelocity = transform.up * _rotationSpeed * horizontalInput;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveVelocity.y = _jumpSpeed;
            }
        }

        moveVelocity.y += _gravity * Time.deltaTime; //gravity

        _controller.Move(moveVelocity * Time.deltaTime); //move the player regulated by constant time
        transform.Rotate(turnVelocity * Time.deltaTime); //turn the player regulated by constant time
    }
    public void IncreaseHealth(int value)
    {
        health += value;
        healthText.text = $"HP:{health}";
    }
}
