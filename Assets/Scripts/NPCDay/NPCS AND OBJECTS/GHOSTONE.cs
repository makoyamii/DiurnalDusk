using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GHOSTONE : MonoBehaviour
{

    public AudioClip click;
    public GameObject interactable;
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;


    public string name;
    public string nameTwo;

    public string dialog;
    public string dialogTwo;

    

    public string dialogThree;
    public string dialogFour;
    public string dialogFive;
    public string dialogSix;
    public string dialogSeven;

    int count = 1;

    bool finished = false;
    bool released = false;

    int countTwo = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OCARINA.isObtained() == false) { //IF THE ANCHOR HAS NOT BEEN FOUND
                if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    soudns.instance.PlaySound(click);
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                        count = 1;
                    } else {
                        dialogBox.SetActive(true);
                        if(count == 1) { //dialogueOne
                            nameText.text = nameTwo;
                            dialogText.text = dialog;
                            count++;
                        } else if (count == 2) { //dialogueTwo
                            nameText.text = name;
                            dialogText.text = dialogTwo;
                            count++;
                        } else if (count == 3) { //dialogThree
                            nameText.text = nameTwo;
                            dialogText.text = dialogThree;
                            count++;
                            //finished = true;
                        } else if (count == 4) { //dialogFour
                            nameText.text = name;
                            dialogText.text = dialogFour;
                            count++;
                            //finished = true;
                        } else if(count == 5) {
                            nameText.text = name;
                            dialogText.text = dialogFive;
                            count++;
                            //finished = true;
                        } else if(count == 6) {
                            nameText.text = name;
                            dialogText.text = dialogSix;
                            count++;
                            //finished = true;
                        } else if(count == 7) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogSeven;
                            count++;
                            finished = true;
                        } 
                    }
            }

        } else { //IF THE ANCHOR HAS BEEN RETRIEVED
            if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                        countTwo++;
                    } else {
                        dialogBox.SetActive(true);
                            nameText.text = name;
                            dialogText.text = dialogThree;
                            finished = true;
                            released = true;
                            countTwo++;
                    }
                
            }
                
        }

        if(released && countTwo == 1) {
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
