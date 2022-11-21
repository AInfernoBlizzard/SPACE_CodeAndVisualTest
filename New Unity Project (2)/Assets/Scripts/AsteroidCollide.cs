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

    private void OnTriggerStay2D(Collider2D Other)
    {
        Debug.Log("Collider works");
        if (Other.gameObject.tag == "Player")
        {
            Debug.Log("Scenec change");
            //SceneManager.LoadScene("InstantLoss");
        }
                
        
    }

}
