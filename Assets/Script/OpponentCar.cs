using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 30f;
    public float breakSpeed = 10f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

    void Start()
    {
        //reglage du centerOfMass
        //GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.9f, 0.2f);
    }

    private void Update()
    {
        Drive();
    }

    public void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= breakSpeed)
            {
                
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Mouvement du vehicule
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime); 
            }
            else
            {
                destinationReached = true;
            }
        }
    }


    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
}
