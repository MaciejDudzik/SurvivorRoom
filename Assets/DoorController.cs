using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject Door;
    public GameObject HelpText;
    public GameObject PickUpText;
    public GameObject KnifesGroup;
    public Material greenMaterial;
    private bool doorOpening;
    private bool playerInArea;
    private bool isUnlocked;
    private bool knifesFlying;

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
            if(!isUnlocked && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)))
            {
                knifesFlying = true;
            }
        }

        if (knifesFlying)
        {
            KnifesGroup.transform.Translate(Vector3.back * Time.deltaTime * 5f);
            foreach(Transform knife in KnifesGroup.transform)
            {
                knife.Rotate(Vector3.left * Time.deltaTime * Random.Range(800, 1300));
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
            PickUpText.SetActive(false);
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
