using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OCARINA : MonoBehaviour
{
    public AudioClip pickup;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
            
            if(dialogBox.activeInHierarchy && finished) {
                dialogBox.SetActive(false);
                finished = false;
            } else {
                dialogBox.SetActive(true);
                if(count == 0) {
                    nameText.text = name;
                    dialogText.text = dialog;
                    count++;
                } else {
                    Destroy(interactable);
                    soudns.instance.PlaySound(pickup);
                    obtained = true;
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


}

