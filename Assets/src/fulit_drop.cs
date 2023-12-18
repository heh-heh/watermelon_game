using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fulit_drop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void drop_f(){
        Transform drop_pos;
        drop_pos = GameObject.FindGameObjectWithTag("drop").GetComponent<Transform>();
        int f_level = Random.Range(0,2);
        Instantiate(gamemanager.f_list_static[f_level], drop_pos);
    }   
}
