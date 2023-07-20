using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timee : MonoBehaviour
{
    
    public float time = 121f;
    public bool CountDownOn = true;
    public string LevelToLoad2;

    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine (timer ());
    }

    // Update is called once per frame
    public void Update()
    {
        if(time<=0)
        {
            SceneManager.LoadScene(LevelToLoad2);
        }
    }

    public IEnumerator timer()
    {
        while(time>0)
        {
            time--;
            yield return new WaitForSeconds (1f);
            GetComponent<Text> ().text = "" + time;
        }
    }
}
