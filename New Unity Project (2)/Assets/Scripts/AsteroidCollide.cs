
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AsteroidCollide : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Scene change");
            SceneManager.LoadScene("InstantLoss");
        }
                
        
    }

}
