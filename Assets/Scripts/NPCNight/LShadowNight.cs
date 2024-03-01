using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LShadowNight : MonoBehaviour
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
        //IF THE ANCHOR HAS BEEN RETRIEVED
                if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    soudns.instance.PlaySound(click);
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                        countTwo++;
                    } else {
                        dialogBox.SetActive(true);
                        if(countTwo == 1) {
                            nameText.text = name;
                            dialogText.text = dialog; //GAH I've been digging through this bin all day but my wretched short paws can't seem to reach the bottom!
                            countTwo++;
                        } else if(countTwo == 2) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogTwo; // Why are you even going through the trash can?
                            countTwo++;
                        } else if(countTwo == 3) {
                            nameText.text = name;
                            dialogText.text = dialogThree; // I'm looking for a photo of my precious Lukie-wukie, It's the last memory that I have of him...
                            countTwo++;
                        } else if(countTwo == 4) {
                            nameText.text = name;
                            dialogText.text = dialogFour; //Oh... my poor Luke...
                            countTwo++;
                        } else if (countTwo == 5) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogFive; //Let me see what I can find.
                            countTwo++;
                        } else if(countTwo == 6) {
                            nameText.text = nameThree;
                            dialogText.text = dialogSix; // You reach into the trashcan and feel around. You find loose change, a photo of a cat, and a piece of a ripped photo.
                            countTwo++;
                        } else if(countTwo == 7) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogSeven; //Is this it?
                            countTwo++;
                        } else if(countTwo == 8) {
                            nameText.text = name;
                            dialogText.text = dialogEight; //My picture! Thank you!
                            countTwo++;
                        } else if(countTwo == 9) {
                            countTwo++;
                            finished = true;
                            released = true;
                        }
                        
                    }
                
                }

            if(released && countTwo == 10) {
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

    
