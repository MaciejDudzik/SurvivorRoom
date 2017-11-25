using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LewerUse : MonoBehaviour {

    public GameObject Safe;
    public GameObject HelpText;
    public GameObject Lever;
    public GameObject Carpet;
    public GameObject WhiteCubePlaceHolder;
    public GameObject BlueCubePlaceHolder;
    private bool safeIsShowing;
    private bool carpetIsMoving;
    private bool playerInArea;
    private bool isActiveted;

    private void Start()
    {
        HelpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInArea && !isActiveted)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                if(WhiteCubePlaceHolder.GetComponent<detectObject>().cubeInArea == true &&
                    BlueCubePlaceHolder.GetComponent<detectObject>().cubeInArea == true)
                {
                    safeIsShowing = true;
                }
                else
                {
                    carpetIsMoving = true;
                }
                    
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
            isActiveted = true;
        }

        if (carpetIsMoving)
        {
            Carpet.transform.Translate(Vector3.back * Time.deltaTime * 10);
        }
        if(Carpet.transform.position.z < -2.4f) 
        {
            carpetIsMoving = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!isActiveted)
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
