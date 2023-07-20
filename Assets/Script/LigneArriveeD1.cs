using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LigneArriveeD1 : MonoBehaviour
{
    public string LevelToLoad2;

    void OnCollisionEnter(Collision collision)
    {
        //Condition de changement de scene apres collision
        if(collision.gameObject.tag == "car")
        {
            
            SceneManager.LoadScene(LevelToLoad2);
        }
    }
        
}
    
    


