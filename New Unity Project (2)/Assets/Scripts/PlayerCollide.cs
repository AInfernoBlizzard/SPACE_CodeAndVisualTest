using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Collider works");
        if (Other.gameObject.tag == "Asteroid")
        {
            Debug.Log("Scene change");
            SceneManager.LoadScene("InstantLoss");
        }


    }

}
