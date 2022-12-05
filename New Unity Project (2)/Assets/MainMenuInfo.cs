using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadInfo()
    {
        SceneManager.LoadScene("MainMenuInfo");
    }

    public void ReturntomainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
