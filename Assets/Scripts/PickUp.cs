using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private bool playerInArea;
    private bool isPickedUp;
    public Canvas PickUpText;
    public Canvas UseText;
    public Transform Hand;
    public bool isPickable;

    private void Start()
    {
    }

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
        if (Hand.childCount == 0 &&
            Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Hand.position;
            transform.parent = GameObject.Find("Hand").transform;
            isPickedUp = true;
            PickUpText.enabled = false;
        }
    }

    private void placeDown()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = GameObject.Find("Pickable").transform; ;
            isPickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isPickable)
            {
                PickUpText.enabled = true;
                UseText.enabled = false;
            }
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = false;
            PickUpText.enabled = false;
        }
    }
}
