using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    public Canvas HelpText;
    public Canvas PickUpText;
    public GameObject Explosion;
    public GameObject Player;
    public GameObject ExplosionArea;
    private bool playerInArea;
    private bool triggered;
    private bool exploded;
    private double timer;

	void Start () {
        timer = 0;
    }
	
	void Update () {


        if (playerInArea)
        {
            if (!exploded && Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                triggered = true;
                Explosion.GetComponent<AudioSource>().Play();
                HelpText.enabled = false;
            }
        }
        if (!exploded && triggered)
        {
            timer = timer + Time.deltaTime;
            if (timer > 5)
            {
                Explosion.GetComponent<ParticleSystem>().Play();
                exploded = true;
                if(ExplosionArea.GetComponent<explosionScript>().playerInArea == true)
                    ExplosionArea.GetComponent<explosionScript>().Kill();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!exploded)
            {
                HelpText.enabled = true;
                PickUpText.enabled = false;
            }
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInArea = false;
            HelpText.enabled = false;
        }
    }
}
