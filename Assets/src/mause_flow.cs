using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class mause_flow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drop_obj;
    public bool drop = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){    
            Vector2 mousePos = Input.mousePosition;
            if(mousePos.x < 650 && mousePos.x > 0f) transform.position = new Vector3((mousePos.x/100)-9.125f, 4,0);
            
        }
        if (Input.GetMouseButtonUp(0)){
            drop = true;
        }
    }
}
