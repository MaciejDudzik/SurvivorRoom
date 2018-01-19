using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SafeController : MonoBehaviour {

    public Canvas safeCanvas;
    public Canvas PickUpText;
    public Canvas HelpText;
    public GameObject player;
    public GameObject door;
    public GameObject id;

    public GameObject focus;
    public Text[] textNumbers = new Text[5];

    public bool isActivated;

    private int focusNumber=-2;
    private int[] numbers = new int[5];
    private bool playerInArea;
    private bool openDoor=false;

    void Start () {
        HelpText.enabled = false;
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = 0;
    }
	
	void Update () {
        if (openDoor)
        {
            door.transform.Rotate(Vector3.left * Time.deltaTime * 20);
            if (door.transform.rotation.x < -0.9999)
            {
                openDoor = false;
                id.GetComponent<PickUp>().isPickable = true;
            }
        }
        if (isActivated && playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                if (safeCanvas.enabled)
                    hideCanvas();
                else
                    showCanvas();
            }
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if(numbers[0]==2 && numbers[1] == 3 && numbers[2] == 1 && numbers[3] == 0 && numbers[4] == 6)
                {
                    isActivated = false;
                    openDoor = true;
                    hideCanvas();
                    id.GetComponent<Rigidbody>().isKinematic = false;
                }
            }


            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && focusNumber<2)
            {
                focusNumber++;
                focus.GetComponent<RectTransform>().localPosition = new Vector3(300 * focusNumber, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && focusNumber > -2)
            {
                focusNumber--;
                focus.GetComponent<RectTransform>().localPosition = new Vector3(300 * focusNumber, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && numbers[focusNumber + 2] < 9)
            {
                numbers[focusNumber + 2]++;
                textNumbers[focusNumber + 2].text = numbers[focusNumber + 2].ToString();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && numbers[focusNumber + 2] > 0)
            {
                numbers[focusNumber + 2]--;
                textNumbers[focusNumber + 2].text = numbers[focusNumber + 2].ToString();
            }
        }
     }

    private void showCanvas()
    {
        safeCanvas.enabled = true;
        player.GetComponent<OVRPlayerController>().HaltUpdateMovement = true;
        HelpText.enabled = false;
        PickUpText.enabled = false;
    }

    private void hideCanvas()
    {
        safeCanvas.enabled = false;
        player.GetComponent<OVRPlayerController>().HaltUpdateMovement = false;
        if (isActivated)
            HelpText.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isActivated)
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
            HelpText.enabled = false;
            playerInArea = false;
        }
    }
}
