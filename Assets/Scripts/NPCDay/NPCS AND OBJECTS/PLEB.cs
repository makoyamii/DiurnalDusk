using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PLEB : MonoBehaviour
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
                if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
                    soudns.instance.PlaySound(click);
                    print("in range and pressed z");
                    if(dialogBox.activeInHierarchy && finished) {
                        dialogBox.SetActive(false);
                        finished = false;
                        count = 1;
                    } else {
                        //
                        dialogBox.SetActive(true);
                        if(count == 1) { //dialogueOne
                            nameText.text = name;
                            dialogText.text = dialog;
                            count++;
                        } else if (count == 2) {
                            nameText.text = name;
                            dialogText.text = dialogTwo;
                            count++;
                        } else if (count == 3) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogThree;
                            count++;
                        } else if (count == 4) {
                            nameText.text = name;
                            dialogText.text = dialogFour;
                            count++;
                        } else if (count == 5) {
                            nameText.text = nameTwo;
                            dialogText.text = dialogFive;
                            count++;
                            finished = true;
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


}
