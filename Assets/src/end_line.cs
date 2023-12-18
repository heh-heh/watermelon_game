using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end_line : MonoBehaviour
{
    // Start is called before the first frame update


    public int f_stay  = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(f_stay>= 2) gamemanager.game_over = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "f"){
            f_stay++;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "f"){
            f_stay--;
        }
    }
}
