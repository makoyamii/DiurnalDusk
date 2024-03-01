using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

public class JazzNight : MonoBehaviour
{

    public GameObject chara;
    public AudioClip ascend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("updating");
        if(DialogueBaseClass.isFinished()) {
            Destroy(chara);
            soudns.instance.PlaySound(ascend);
        }
    }
}
