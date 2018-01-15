using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    public GameObject HelpText;
    public GameObject PickUpText;
    public GameObject Explosion;
    public GameObject Player;
    private bool playerInArea;
    private bool triggered;
    private bool exploded;
    private double timer;

	void Start () {
        HelpText.SetActive(false);
        timer = 0;
    }
	
	void Update () {
        if (playerInArea)
        {
            if (!exploded && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                triggered = true;
                Explosion.GetComponent<AudioSource>().Play();
                HelpText.SetActive(false);
            }
        }
        if (!exploded && triggered)
        {
            timer = timer + Time.deltaTime;
            if (timer > 5)
            {
                Explosion.GetComponent<ParticleSystem>().Play();
                exploded = true;
                if (playerInArea)
                {   
                    Player.GetComponent<Health>().Kill();
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HelpText.SetActive(true);
            PickUpText.SetActive(false);
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
