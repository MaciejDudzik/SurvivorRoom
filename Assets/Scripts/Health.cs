using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private bool alive;
    public Canvas EndGameText;
    public Canvas HelpText;
    public GameObject Player;
    public Canvas pickText;

    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    public void Kill()
    {
        alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                SceneManager.LoadScene("Scene1");
            }

            alive = false;
            EndGameText.enabled = true;
            Player.GetComponent<OVRPlayerController>().HaltUpdateMovement = true;
            pickText.enabled = false;
            HelpText.enabled = false;
        }
    }
}
