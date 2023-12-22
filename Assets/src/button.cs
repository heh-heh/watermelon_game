using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void game_reset(){
        gamemanager.score = 0;
        gamemanager.game_pause = !gamemanager.game_pause;
        SceneManager.LoadScene("main");
    }
    public void on_button(){
        gamemanager.game_pause = !gamemanager.game_pause;
    }

    public void game_ext(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
