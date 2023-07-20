using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public Text TxtSpeed;
    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider back_left;
    public WheelCollider back_right;
    public float Torque;
    public float Speed;
    public float MaxSpeed = 200f;
    public int Brake = 10000;
    public float CoefAcceleration = 50f;
    public float WheelAngleMax = 10f;
    public float DAmax = 40f;
    public bool Freinage = false;
    public GameObject BackLight;

    void Start()
    {
        //reglage du centerOfMass
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.9f, 0.2f);
    }

    
    void Update()
    {
        //Son du moteur
        GetComponent<AudioSource>().pitch = Speed / MaxSpeed + 0.2f;

        //Affichage de la vitesse
        Speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        TxtSpeed.text = "Speed : " + (int)Speed;
        //Acceleration
        if(Input.GetKey(KeyCode.UpArrow) && Speed < MaxSpeed)
        {
            if(!Freinage)
            {
                front_left.brakeTorque = 0;
                front_right.brakeTorque =0;
                back_left.brakeTorque = 0;
                back_right.brakeTorque = 0;
                back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
                back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
            }
            
        }

        //Décélèration
        if(!Input.GetKey(KeyCode.UpArrow) && !Freinage || Speed > MaxSpeed)
        {
            Debug.Log("décélération");
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
            back_left.brakeTorque = Brake * CoefAcceleration *Time.deltaTime;
            back_right.brakeTorque = Brake * CoefAcceleration *Time.deltaTime;
        }

        //Direction du véhhicule
        float DA = (((WheelAngleMax - DAmax) / MaxSpeed) * Speed) + DAmax;
        Debug.Log(DA);

        front_left.steerAngle = Input.GetAxis("Horizontal") * DA;
        front_right.steerAngle = Input.GetAxis("Horizontal") * DA;
        //freinage
        if(Input.GetKey(KeyCode.Space))
        {
            Freinage = true;
            BackLight.SetActive(true);
            back_left.brakeTorque = Mathf.Infinity;
            back_right.brakeTorque = Mathf.Infinity;
            front_left.brakeTorque = Mathf.Infinity;
            front_right.brakeTorque = Mathf.Infinity;
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;

        }
        else
        {
            Freinage = false;
            BackLight.SetActive(false);
        }

        //Marche Arrière
        if(Input.GetKey(KeyCode.DownArrow))
        {
            front_left.brakeTorque = 0;
            front_right.brakeTorque =0;
            back_left.brakeTorque = 0;
            back_right.brakeTorque = 0;
            back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
            back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
        }
    }
}
