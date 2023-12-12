using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool game_over = false;
    static public int game_over_time;

    public bool game_over2;
    static public int score = 0;
    public List<GameObject> f_list = new List<GameObject>();
    static public  List<GameObject> f_list_static = new List<GameObject>();
    public Transform drop_pos;
    
    void Start()
    {
        f_list_static = f_list;
        //fulit_drop.drop_f();

    }

    // Update is called once per frame
    void Update()
    {
        game_over2=game_over;
        if(game_over) {
            Time.timeScale =0;
        }
    }
}
