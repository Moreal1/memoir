using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananage : MonoBehaviour
{
    Text TxtInfo;
    
    
    void Start()
    {
        TxtInfo = GetComponent<Text> ();
        TxtInfo.text = "La touche A pour Démarrer";
        StopGame ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.A))
        {
            StartCoroutine(Decompte ());
        }
    }
        //condition de coroutine
    IEnumerator Decompte ()
    {
        TxtInfo.GetComponent<Text> ().enabled = true;

        for(int i = 3; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            TxtInfo.text = ""+ i;
        }

        TxtInfo.text = "GO...";
        StartGame();
        yield return new WaitForSeconds (2);
        TxtInfo.text = "";
    }
    
    //Fonction pour arreter le jeu
    void StopGame()
    {
        GameObject cars;
        cars = GameObject.FindGameObjectWithTag("car");
        cars.GetComponent<OpponentCar> ().enabled = false;

        GameObject carss;
        carss = GameObject.FindGameObjectWithTag("car2");
        carss.GetComponent<OpponentCar> ().enabled = false;

        GameObject PlayerCar;
        PlayerCar = GameObject.FindGameObjectWithTag("Player");
        PlayerCar.GetComponent<control> ().enabled = false;
        PlayerCar.GetComponent<AudioSource> ().Stop ();

        
    }

    //Fonction de démarrage u jeu
    void StartGame()
    {
        GameObject cars;
        cars = GameObject.FindGameObjectWithTag("car");
        cars.GetComponent<OpponentCar> ().enabled = true;

        GameObject carss;
        carss = GameObject.FindGameObjectWithTag("car2");
        carss.GetComponent<OpponentCar> ().enabled = true;

        GameObject PlayerCar;
        PlayerCar = GameObject.FindGameObjectWithTag("Player");
        PlayerCar.GetComponent<control> ().enabled = true;
        PlayerCar.GetComponent<AudioSource> ().Play ();

        /*Text Temps;
        Temps = GameObject.FindWithTag("temp").GetComponent<Text>();
        Temps.GetComponent<Timee> ().enabled = true;*/

    }
}
