using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // speed variable.
    public float spd = 10f;
    // height of jump.
    public float jumpForce = 50f;
    private Rigidbody rigidbody;
    // Determines whether jump is possible.
    private bool jump = false;
    // Determines whether or not player is on the ground.
    private bool grounded = false;
    // player hitpoints.
    public int lives = 100;
    private Vector3 startPos;
    // Determines whether or not player is invulnerable.
    private bool isInvincible;
    // Start is called before the first frame update
    void Start()
    {
        // Determines starting position.
        startPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if A key is pressed, player will move left.
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move the player left");
            transform.position += Vector3.left * spd * Time.deltaTime;
        }
        // if D key is pressed, player will move right.
        if (Input.GetKey(KeyCode.D))

        {
            Debug.Log("Move the player left");
            transform.position += Vector3.right * spd * Time.deltaTime;
        }
        // if W key is pressed, player will jump.
        if (Input.GetKeyDown(KeyCode.W))

        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Jump");
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    // function for player to blink.
    private void playerHit()
    {
        StartCoroutine(Blink());
    }
    // player blinks.
    private IEnumerator Blink()
    {
        isInvincible = true;
        //when script gets to this line,the coroutine will wait 1 second before continuing
        yield return new WaitForSeconds(0.1f);

        for (int index = 0; index < 30; index++)
        {
            //if index is even disable mesh renderer, if odd, enable
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
        isInvincible = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")

        {
            startPos = other.gameObject.GetComponent<Portal>().SpawnPoint.transform.position;
            transform.position = startPos;
        }
    }
}
