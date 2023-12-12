using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class f_cs : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public bool ck = false;
    bool ck1 = false;
    public bool f_drop = true;
    public Rigidbody2D rigid;
    public GameObject drop_obj;
    public bool end_line_r = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        drop_obj = GameObject.FindGameObjectWithTag("drop_obj");
    }

    // Update is called once per frame
    void Update()
    {
        // if(!f_drop){
        //     //transform.position = drop_obj.transform.position;
        //     rigid.gravityScale = 0;
        // }
        // else
        // {
        //     //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //     rigid.gravityScale = 2;
        // }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "drop_obj"){
            mause_flow other2 = other.collider.GetComponent<mause_flow>();
            if(other2.drop){f_drop = true;}
        }
        else if(other.collider.tag == "f"){
            f_cs other2 = other.collider.GetComponent<f_cs>();
            if(other2.level == level && level < 10){
                float o_x = other.transform.position.x;
                float o_y = other.transform.position.y;
                float m_x = transform.position.x;
                float m_y = transform.position.y;
                if(m_y < o_y){
                    other2.h(transform.position);
                    if(!ck1)Level_up();
                }
            }
        }
    }

    public void h(Vector3 target){
        ck = true;
        rigid.simulated = false;
        StartCoroutine(h2(target));
    }
    IEnumerator h2(Vector3 target){
        for(int i=0; i<20; i++){
            transform.position = Vector3.Lerp(transform.position, target, 0.5f);
            yield return null;
        }
        Destroy(gameObject);
    }
    public void Level_up(){
        ck = true;ck1=true;
        Instantiate(gamemanager.f_list_static[level+1], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
