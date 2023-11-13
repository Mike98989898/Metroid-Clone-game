using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool go = true;
    
    // Start is called before the first frame update
    void Start()
    {
        

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))

        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.D))

        {
            rb.velocity = -transform.right * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Enemy")
        {
            Object.Destroy(this.gameObject);
        }
        if (other.tag == "BigEnemy")
        {
            Object.Destroy(this.gameObject);
        }
        
    }

}
