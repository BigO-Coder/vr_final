using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,3.0f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") //子彈碰到地板時
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Obstacle") //子彈碰到障礙物時
        {
            //Destroy(gameObject);
        }
    }
}
