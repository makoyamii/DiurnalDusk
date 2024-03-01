using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BED : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public Text nameText;
    bool playerInRange;

    public string dialog;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
            if(dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            } else {
                    //textbox is displayed
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    nameText.text = name;
                    //press x to sleep
                    //CODE THE OPTION OR PRESS A BUTTON TO MOVE TO THE NEXT SCENE
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
