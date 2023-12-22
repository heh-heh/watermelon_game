using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool game_over = false;
    static public int game_over_time;
    static public bool game_pause = false;
    public bool game_over2;
    static public int score = 0;
    public int best_score = 0;
    public List<GameObject> f_list = new List<GameObject>();
    static public  List<GameObject> f_list_static = new List<GameObject>();
    public Transform drop_pos;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI best_score_text;
    public GameObject game_over_UI;
    public GameObject Ese_UI;
    void Start()
    {
        f_list_static = f_list;
        fulit_drop.drop_f();
        best_score = PlayerPrefs.GetInt("best_score");
        best_score_text.text = ""+best_score;
    }

    // Update is called once per frame
    void Update()   
    {
        
        score_text.text = ""+score;
        game_over2=game_over;
        Ese_UI.SetActive(false);
        if(Input.GetButtonDown("Cancel")){
            game_pause = !game_pause;
        }
        UI_sh();
    }
    void UI_sh(){
        if(game_over || game_pause) {
            Time.timeScale = 0;
            if(game_pause)Ese_UI.SetActive(true);
        }
        else Time.timeScale = 1;
        if(game_over){
            game_over_UI.SetActive(true);
            if(best_score<score){
                PlayerPrefs.SetInt("best_score",score);
            }
        }
        
    }
}
