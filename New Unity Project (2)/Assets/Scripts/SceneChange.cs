using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public List<int> ListOfScenes;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 21; i++)
        {
            ListOfScenes.Add(i);
        }
    }

    public void LoadRandomScene()
    {
        int index = Random.Range(0, ListOfScenes.Count-1);
        int newScene = ListOfScenes[index];
        SceneManager.LoadScene(newScene);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}