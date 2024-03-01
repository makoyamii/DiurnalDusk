using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

public class RestrictMovement : MonoBehaviour
{

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueBaseClass.isFinished() == true) {
            Destroy(one);
            Destroy(two);
            Destroy(three);
            Destroy(four);
        }
        
    }
}
