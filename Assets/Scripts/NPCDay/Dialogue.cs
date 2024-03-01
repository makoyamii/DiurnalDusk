using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{      
    public Collider2D NPC;
    public Text textComponent;
    public GameObject textbox;

    public string[] lines;
    public float textSpeed;
    private int index;

    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange) {
            if(textbox.activeInHierarchy) {
                textbox.SetActive(false);
            } else {
                    textbox.SetActive(true);
                if(textComponent.text == lines[index]) {
                    NextLine();
                } else {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach(char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if(index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
        }
    }

    //CHECK IF THE OBJECT IS IN RANGE
    private void OnTriggerEnter2D() {
        if(NPC.CompareTag("Player")) {
            playerInRange = true;
        }
    }
            

    private void OnTriggerExit2D() {
        if(NPC.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}
