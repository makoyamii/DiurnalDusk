using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PHONE : MonoBehaviour
{
    public AudioClip telefono;
    /*
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    */
    bool playerInRange;

    /*
    public string dialog;
    public string dialogTwo;
    public string name;
    */
    private int enter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    StartCoroutine(waiter());
                
            
        } 

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = true;
        }
    }
        

    

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerInRange = false;
        }
    }

    IEnumerator waiter() {
        //play phone ringing sound
        soudns.instance.PlaySound(telefono);
        //wait for 1 second and then move to the final scene
        yield return new WaitForSeconds(1);              
        SceneManager.LoadScene("Ending");
        

    }


}
