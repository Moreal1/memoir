using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananage1 : MonoBehaviour
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
        GameObject PlayerCar;
        PlayerCar = GameObject.FindGameObjectWithTag("Player");
        PlayerCar.GetComponent<control> ().enabled = false;
        PlayerCar.GetComponent<AudioSource> ().Stop ();

        Text Temps;
        Temps = GameObject.FindWithTag("temp").GetComponent<Text>();
        Temps.GetComponent<Timee> ().enabled = false;
    }

    //Fonction de démarrage u jeu
    void StartGame()
    {
        GameObject PlayerCar;
        PlayerCar = GameObject.FindGameObjectWithTag("Player");
        PlayerCar.GetComponent<control> ().enabled = true;
        PlayerCar.GetComponent<AudioSource> ().Play ();

        Text Temps;
        Temps = GameObject.FindWithTag("temp").GetComponent<Text>();
        Temps.GetComponent<Timee> ().enabled = true;

    }
}
