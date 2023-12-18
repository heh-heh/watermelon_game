using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class f_cs : MonoBehaviour
{
    public int level;
    bool ck = false;
    bool ck1 = false;
    public bool f_drop = false;
    public Rigidbody2D rigid;
    public Transform drop_obj;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        drop_obj = GameObject.FindGameObjectWithTag("drop_obj").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if(f_drop == false){
            transform.position = new Vector2(drop_obj.transform.position.x,drop_obj.transform.position.y);
            rigid.simulated = false;
            if (Input.GetMouseButtonUp(0)&&f_drop==false){
                f_drop = true;
            }
        }
        else if(f_drop == true){
            if(ck==false){
                rigid.gravityScale = 2; rigid.simulated = true;
                transform.position = new Vector2(transform.position.x, transform.position.y);ck=true;
                Invoke("drop_ff",0.5f); 
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "f"){
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
                else if (m_x>o_x && m_y==o_y){
                    other2.h(transform.position);
                    if(!ck1)Level_up();
                }
            }
        }
    }

    void drop_ff(){
        Debug.Log("drop");
        Transform drop_pos;
        drop_pos = GameObject.FindGameObjectWithTag("drop").GetComponent<Transform>();
        int f_level = Random.Range(0,2);
        GameObject ff = Instantiate(gamemanager.f_list_static[f_level], drop_pos);
        f_cs other = ff.GetComponent<f_cs>();
        other.f_drop = false;
    }
    public void h(Vector3 target){
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
        Debug.Log("levelUP");
        rigid.simulated = false;
        gamemanager.score += (level+1)*20; 
        ck1=true;
        GameObject ff =  Instantiate(gamemanager.f_list_static[level+1], transform.position, transform.rotation);
        f_cs other = ff.GetComponent<f_cs>();
        other.f_drop = true;
        other.ck= true;
        Destroy(gameObject);
    }
}
