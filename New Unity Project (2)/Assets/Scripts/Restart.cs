using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart: MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName: "Scene 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
