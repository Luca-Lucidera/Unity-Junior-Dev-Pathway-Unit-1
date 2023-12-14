using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //farà 5 metri al secondo
    private float speed = 20;
    private float turnSpeed = 45;
    private float horizontalInput;
    private float forwardSpeed;

    void Start()
    {
    }

    //Questa funzione viene chiamata ad ogni frame (60 volte al secondo)
    void Update()
    {
        //Il nome lo trovi in Edit -> Project Settings -> Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        forwardSpeed = Input.GetAxis("Vertical");

        //Muoviamo il veicolo in avanti o indietro per 5 metri al secondo
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardSpeed);
      
        //Prendiamo l'angolo di rotazione
        var angolo = Time.deltaTime * turnSpeed * horizontalInput;

        //Utilizziamo UP perchè abbiamo bisogno di ruotare il veicolo sull'asse delle Y (pensala come girare una penna in verticale)
        transform.Rotate(Vector3.up * angolo);
    }
}