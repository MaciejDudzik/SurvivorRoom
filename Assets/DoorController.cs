using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject Door;
    public GameObject HelpText;
    public Material greenMaterial;
    private bool doorOpening;
    private bool playerInArea;
    private bool isUnlocked;

    private void Start()
    {
        HelpText.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (playerInArea)
        {
            if (isUnlocked && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)))
            {
                doorOpening = true;
            }
        }

        if (doorOpening == true)
        {
            Door.transform.Translate(Vector3.back * Time.deltaTime * 2);
        }
        if(Door.transform.position.z < -3.55f)
        {
            doorOpening = false;
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HelpText.SetActive(true);
            playerInArea = true;
        }

        if (other.tag == "ID")
        {
            GetComponent<Renderer>().material = greenMaterial;
            isUnlocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = false;
            HelpText.SetActive(false);
        }
    }
}
