using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public AudioClip death;
    public Transform player;
    public float moveSpeed = 5f;
    private bool playerInRange;

    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        movement = direction;
        if(playerInRange) {
            StartCoroutine(waiter());            
        } else {
            CinemachineShake.Instance.ShakeCamera(0f, 0f);
        }
    }

    void FixedUpdate() {
        moveCharacter(movement);
    }        

    void moveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)(transform.position) + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = false;
        }
    }
    */

    //wait before going to game over
    IEnumerator waiter() {
        CinemachineShake.Instance.ShakeCamera(5f, 1f);
        soudns.instance.PlaySound(death);
        //wait for 1 second and then move to the final scene
        yield return new WaitForSeconds(.5f);              
        SceneManager.LoadScene("GameOver");
        

    }


}



