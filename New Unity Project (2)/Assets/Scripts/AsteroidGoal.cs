using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider works");
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Scene change");
            SceneManager.LoadScene("MiniGameWin");
        }


    }
}
