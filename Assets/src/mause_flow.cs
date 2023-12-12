using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            if(mousePos.x < 650 && mousePos.x > 0f) this.transform.position = new Vector3((mousePos.x/100)-9.125f, 4,0);
        }
        if (Input.GetMouseButtonUp(0)){
            Debug.Log("drop");
            drop = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "f"){
            f_cs other2 = other.GetComponent<f_cs>();
            if(!drop){
                other.transform.position = drop_obj.transform.position;
                other2.rigid.gravityScale = 0;
            }
            else if(drop){
                other2.rigid.gravityScale = 2;
            }
        }
    }
}
