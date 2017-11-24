using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LewerUse : MonoBehaviour {

    public GameObject Safe;
    public GameObject HelpText;
    public GameObject Lever;
    private bool safeIsShowing;
    private bool playerInArea;

    private void Start()
    {
        HelpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                safeIsShowing = true;
            }
        }

        if (safeIsShowing == true)
        {
            Safe.transform.Translate(Vector3.left * Time.deltaTime * 1);
            Lever.transform.Rotate(Vector3.back * Time.deltaTime * 10);
        }
        if (Safe.transform.position.x < 8f)
        {
            safeIsShowing = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HelpText.SetActive(true);
            playerInArea = true;
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
