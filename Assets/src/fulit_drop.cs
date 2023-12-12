using System.Collections;
using System.Collections.Generic;
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
        drop_pos = GameObject.FindGameObjectWithTag("drop_obj").GetComponent<Transform>();
        int f_level = Random.Range(0,2);
        GameObject ff = Instantiate(gamemanager.f_list_static[f_level], drop_pos);
    }
}
