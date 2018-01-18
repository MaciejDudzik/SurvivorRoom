using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private bool alive;
    public GameObject EndGameText;
    public GameObject RestartText;
    public GameObject Player;
    public GameObject pickText;

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
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scene1");
            }

            alive = false;
            EndGameText.SetActive(true);
            RestartText.SetActive(true);
            Player.GetComponent<OVRPlayerController>().HaltUpdateMovement = true;
            pickText.SetActive(false);
        }
    }
}
