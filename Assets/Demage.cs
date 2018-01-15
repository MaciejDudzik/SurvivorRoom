using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demage : MonoBehaviour {

    public GameObject Player;
    public GameObject HelpText;
    private bool playerInArea;
    private bool doeasDemage;

    // Use this for initialization
    void Start () {
        playerInArea = false;
        doeasDemage = true;
    }

    public void StopDoingDemage()
    {
        doeasDemage = false;
    }

    // Update is called once per frame
    void Update () {
        if (doeasDemage && playerInArea)
        {
            Player.GetComponent<Health>().Kill();
            HelpText.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = false;
        }
    }
}
