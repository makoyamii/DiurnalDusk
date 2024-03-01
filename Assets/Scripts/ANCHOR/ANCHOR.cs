using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANCHOR : MonoBehaviour
{
    public AudioClip pickup;
    public AudioClip exclamation;

    public GameObject interactable;    
    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;

    public string dialog;
    public string dialogTwo;
    public string name;

    int count = 0;
    bool finished = false;
    public static bool obtained = false;

    public static int numOfPhotos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
            if(dialogBox.activeInHierarchy && finished) {
                print("if");
                dialogBox.SetActive(false);
                finished = false;
            } else {
                print("else");
                print(numOfPhotos);
                dialogBox.SetActive(true);
                if(count == 0) {
                    if(numOfPhotos < 3) {
                        nameText.text = name;
                        dialogText.text = dialog;
                        count++;
                    } else if (numOfPhotos == 3) {
                        nameText.text = name;
                        //play exclamation sound
                        soudns.instance.PlaySound(exclamation);
                        dialogText.text = "You've collected all pieces. It's a family photo. Something is telling you to go to the telephone booth just outside town.";
                        count++;
                    }
                    
                } else {
                    numOfPhotos++;
                    soudns.instance.PlaySound(pickup);
                    Destroy(interactable);
                    obtained = true;
                    print(numOfPhotos);
                }
                
                //nameText.text = dialog;
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

    public static bool isObtained() {
        return obtained;
    }

    public static int canEnter() {
        return numOfPhotos;
    }
}
