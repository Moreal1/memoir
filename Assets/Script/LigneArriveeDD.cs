using UnityEngine;
using UnityEngine.SceneManagement;

public class LigneArriveeDD : MonoBehaviour
{
    public string LevelToLoad;

    void OnCollisionEnter(Collision collision)
    {
        //Condition de changement de scene apres collision
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Condition satisfaite : La voiture a atteint la ligne d'arrivée !");

            SceneManager.LoadScene(LevelToLoad);
        }
    }
    
    
}

