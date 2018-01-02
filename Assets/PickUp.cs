using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private bool playerInArea;
    private bool isPickedUp;
    public Transform Hand;
    public bool isPickable;

    // Update is called once per frame
    void Update () {
        if (playerInArea && isPickable)
        {
            if (isPickedUp)
                placeDown();
            else
                pickUp();        
        }
    }

    private void pickUp()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.position = Hand.position;
            //transform.localPosition = new Vector3(2, 2, -0.5f);
            transform.parent = GameObject.Find("Hand").transform;
            isPickedUp = true;
        }
    }

    private void placeDown()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = GameObject.Find("Pickable").transform; ;
            isPickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //HelpText.SetActive(true);
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = false;
            //HelpText.SetActive(false);
        }
    }
}
