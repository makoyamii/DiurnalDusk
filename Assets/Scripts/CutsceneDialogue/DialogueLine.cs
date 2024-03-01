using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem {
    public class DialogueLine : DialogueBaseClass
    {   
        private Text textHolder;
        [SerializeField]private string input;

        [SerializeField] private AudioClip sound;

        //displaying the character name
        [SerializeField] private string name;
        [SerializeField] private Text nameHolder;
        [SerializeField] private bool nextScene;

        private void Awake() {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            
            nameHolder.text = name;
        }

        private void Start() {
            StartCoroutine(WriteText(input, textHolder, sound, nextScene));
        }
    }

}
