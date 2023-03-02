using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("Level1");
    }
    public void FullScreen(){
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Screen");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit(){
        Application.Quit();
    }
    
}
