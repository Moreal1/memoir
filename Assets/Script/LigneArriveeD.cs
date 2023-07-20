using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LigneArriveeD : MonoBehaviour
{
    public string LevelToLoad;

    void OnCollisionEnter(Collision collision)
    {
        //Condition de changement de scene apres collision
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Condition satisfaite : La voiture a atteint la ligne d'arrivée !");

            SceneManager.LoadScene(LevelToLoad);
        }
        
    }
    
    
}

