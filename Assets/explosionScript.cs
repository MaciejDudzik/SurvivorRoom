using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour {

    public GameObject Player;
    bool executeKill, playerInArea, exploded;

	// Use this for initialization
	void Start () {
        executeKill = false;
        playerInArea = false;
        exploded = false;

    }

    public void Kill()
    {
        executeKill = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(playerInArea && !exploded && executeKill)
        {
            exploded = true;
            Player.GetComponent<Health>().Kill();
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
