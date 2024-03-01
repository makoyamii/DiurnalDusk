using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace DialogueSystem {

    public class DialogueBaseClass : MonoBehaviour
    {

        public AudioClip click;

        public static bool amFinished = false;
        //this script deals with displaying each character at a time
        public bool finished {get; private set;}
        protected IEnumerator WriteText(string input, Text textHolder, AudioClip sound, bool nextScene) {
            for(int i = 0; i < input.Length; i++) {
                textHolder.text += input[i];
                //SoundManager.instance.PlaySound(sound);
                //play letter
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Z));
            finished = true;
            soudns.instance.PlaySound(click);
            if(nextScene) {
                amFinished = true;
            }
            
        }

        public static bool isFinished() {
            return amFinished;
        }
        
    }

}
