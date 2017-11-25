using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectObject : MonoBehaviour {

    public bool cubeInArea;
    public GameObject cube;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == cube.tag)
        {
            //HelpText.SetActive(true);
            cubeInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == cube.tag)
        {
            cubeInArea = false;
            //HelpText.SetActive(false);
        }
    }
}
