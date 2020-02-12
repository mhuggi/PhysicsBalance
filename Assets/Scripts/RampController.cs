using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    GameObject box;
    Vector2 velocity;
    float angle;
    float rad;
    float norm;
    float Fu;
    float Fy;
    float Fx;
    float gravity;
    float result;
    float mass;
    float Us;

    // Start is called before the first frame update

    void Start()
    {
        box = GameObject.Find("box");
        velocity = new Vector2(0, 0);
        gravity = -0.98f;
        mass = 2f;
        Us = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        rad = angle * Mathf.Deg2Rad;
        norm = Mathf.Cos(rad) * gravity;
        Fy = norm;
        Fu = -Us * norm;
        Fx = Mathf.Sin(rad) * gravity;
        result = Fx - Fu;




        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            angle--;
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            angle++;
            transform.Rotate(0, 0, 1);
        }

        
        
        if (Fx > Us || velocity.x > 0) {

            float acceleration = ((result) / mass) * Time.deltaTime;
            
            velocity.x += acceleration;
            Debug.Log(velocity.x);
            if (velocity.x < 0.00001f)
            {
                velocity.x = 0;
            }
        }
        box.transform.Translate(velocity);



        Debug.Log(velocity.x);

    }
}
