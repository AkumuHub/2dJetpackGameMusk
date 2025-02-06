using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    AudioManager audioManager;




    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene1()
    {
        audioManager.PlaySFX(audioManager.start);
        SceneManager.LoadScene("Level 1"); 
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }
}
