using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpponentCarWaypoint : MonoBehaviour
{
    [Header("OpponentCar")]
    public OpponentCar opponentCar;
    public Waypoint currentWaypoint;
    

    private void Awake()
    {
        opponentCar = GetComponent<OpponentCar>();
    }

    private void Start()
    {
        opponentCar.LocateDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if(opponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            opponentCar.LocateDestination(currentWaypoint.GetPosition());
        }

        
    }
}
