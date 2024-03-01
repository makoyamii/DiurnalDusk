using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SUNFISH : MonoBehaviour
{

    public AudioClip click;
    public GameObject interactable;
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;


    public string name;
    public string dialog;

    int count = 1;

    bool finished = false;
    bool released = false;
    int countTwo = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //IF THE ANCHOR HAS BEEN RETRIEVED
                if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    soudns.instance.PlaySound(click);
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                        countTwo++;
                    } else {
                        dialogBox.SetActive(true);
                        if(count == 1) {
                            nameText.text = name;
                            dialogText.text = dialog; //glug glug
                            count++;
                        } else if(count == 2) {
                            countTwo++;
                            finished = true;
                            //released = true;
                        }
                        
                    }
                
                }

            if(released && countTwo == 3) {
            Destroy(interactable);
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
        
}

    
