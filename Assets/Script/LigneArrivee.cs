using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LigneArrivee : MonoBehaviour
{
    public string LevelToLoad;
   

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Condition satisfaite : La voiture a atteint la ligne d'arrivée !");

            SceneManager.LoadScene(LevelToLoad);
        }
       
    }
    
    
}

