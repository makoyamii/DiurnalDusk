using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TELEPHONE : MonoBehaviour
{
    public AudioClip click;
    
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;

    public string dialog;
    public string dialogTwo;
    public string name;
    private int enter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        enter = ANCHOR.canEnter();

        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
            soudns.instance.PlaySound(click);
            if(enter == 4) {
                print("inside the if");
                if(dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
                } else {
                    StartCoroutine(waiter());
                }
            } else {
                print("inside the else");
                if(dialogBox.activeInHierarchy) {
                    dialogBox.SetActive(false);
                } else {
                    dialogBox.SetActive(true);
                    dialogText.text = dialogTwo;
                    nameText.text = name;
                }
            }
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
            dialogBox.SetActive(false);
        }
    }

    IEnumerator waiter() {
        //textbox is displayed
                        
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        nameText.text = name;
        //wait for 1 second and then move to the final scene
        yield return new WaitForSeconds(1);              
        SceneManager.LoadScene("Phonebooth");
        

    }


}
