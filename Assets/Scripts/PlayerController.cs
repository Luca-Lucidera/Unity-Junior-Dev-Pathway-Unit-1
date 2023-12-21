using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> wheels;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 30f;


    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float rpm;
    private int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    void FixedUpdate()
    {
        //Il nome lo trovi in Edit -> Project Settings -> Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Il pezzo sotto commentato non va bene perché applica la forza a livello globale e non a livello locale
            //playerRb.AddForce(Vector3.forward * horsePower * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //Prendiamo l'angolo di rotazione
            var angolo = Time.deltaTime * turnSpeed * horizontalInput;

            //Utilizziamo UP perch� abbiamo bisogno di ruotare il veicolo sull'asse delle Y (pensala come girare una penna in verticale)
            transform.Rotate(Vector3.up * angolo);

            //rigidBody.velocity.magnitude ritorna la velocità dell'rigid body in metri al secondo, quindi noi dobbiamo trasformarlo in chilometri al secondo
            speed = playerRb.velocity.magnitude * 3.6f;
            speedometerText.text = $"Speed: {Mathf.RoundToInt(speed)} km/h";

            rpm = (speed % 30) * 40;
            rpmText.SetText($"RPM: {Mathf.RoundToInt(rpm)}");
        }
    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (var wheel in wheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround == 4;
    }
}