using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2 (2,0).normalized;
        rigid.AddForce (arah*force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text> ();
        scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text> ();  
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            ResetBall();
            Vector2 arah = new Vector2(2,0).normalized; // vector positif
            rigid.AddForce(arah * force); 
        }
        if(other.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            ResetBall();
            Vector2 arah = new Vector2(-2,0).normalized; //vector negatif
            rigid.AddForce(arah * force); 
        }
        //kondisi kena padle
        if(other.gameObject.name == "Pemukul" || other.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y-other.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x,sudut).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah * force * 2);
        }       
    }
    //fungsi reset bola
    void ResetBall()
    {
        transform.localPosition = new Vector2(0,0);
        rigid.velocity = new Vector2(0,0);
    }
    void TampilkanScore ()
    {
        Debug.Log ("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}
