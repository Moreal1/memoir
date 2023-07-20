using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCounter : MonoBehaviour
{
    public Text SurviveTxt;
    public string LevelToLoad;
    public int collisionLimit = 5;  // Nombre de collisions maximum avant de recommencer le niveau
    public int collisionCount = 0; // Compteur de collisions

    

    // Méthode appelée lorsqu'une collision se produit
    public void OnCollisionEnter(Collision collision)
    {

        // Vérifie si la collision implique une voiture
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Finish")
        {
            collisionLimit--; //décrémente la limite de la collision
            collisionCount++; // Incrémente le compteur de collisions

        }
    }

    void Update()
    {
        SurviveTxt.text = "Vie : " + collisionLimit;

        if (collisionLimit <= 0)
        {
            // Appel d'une méthode pour recommencer le niveau
            RestartLevel();
        
        }

        

    }

    // Méthode pour recommencer le niveau
    public void RestartLevel()
    {
        // Code pour recommencer le niveau, par exemple :
        SceneManager.LoadScene(LevelToLoad);
    }
}
