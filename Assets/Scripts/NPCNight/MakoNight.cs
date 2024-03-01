using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakoNight : MonoBehaviour
{
    public AudioClip click;
    public AudioClip ascend;

    public GameObject interactable;
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;


    public string name;
    public string nameTwo;
    public string nameThree;

    public string dialog;
    public string dialogTwo;

    

    public string dialogThree;
    public string dialogFour;
    public string dialogFive;
    public string dialogSix;
    public string dialogSeven;
    public string dialogEight;

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
                            nameText.text = name;
                            dialogText.text = dialog;
                            count++;
                        } else if (count == 2) { //dialogueTwo
                            nameText.text = name;
                            dialogText.text = dialogTwo;
                            count++;
                            finished = true;
                        }
                    }
            }

        } else { //IF THE ANCHOR HAS BEEN RETRIEVED
            if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                soudns.instance.PlaySound(click);
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                    } else {
                        dialogBox.SetActive(true);
                        if(countTwo == 1) {
                            nameText.text = name;
                            dialogText.text = dialogThree; //Oh my gosh! My sheet music!
                            countTwo++;
                        } else if(countTwo == 2) {
                            nameText.text = nameThree;
                            dialogText.text = dialogFour; //Mako takes the music sheet and plays her ocarina. She plays it beatifully. When she finishes, she looks up with a bright smile.
                            countTwo++;
                        } else if(countTwo == 3) {
                            nameText.text = name;
                            dialogText.text = dialogFive; //Thank you so much. I can finally rest in peace.
                            countTwo++;
                        } else if(countTwo == 4) {
                            nameText.text = name;
                            dialogText.text = dialogSix; //By the way, next to me is a photo piece I picked up. Although it's ripped, it looks important.
                            countTwo++;
                        } else if(countTwo == 5) {
                            nameText.text = name;
                            dialogText.text = dialogSeven; //You were all such a happy family... Thanks again.
                            countTwo++;
                        } else if(countTwo == 6) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogEight; //Wait, a happy family... How did you know that about me--
                            countTwo++;
                            finished = true;
                            released = true;
                        } 
                            
                            
                    }
                
            }
                
        }

        if(released && countTwo == 7) {
            soudns.instance.PlaySound(ascend);
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
