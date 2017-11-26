using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeController : MonoBehaviour {

    public Canvas safeCanvas;
    public GameObject HelpText;
    public GameObject player;
    public GameObject door;

    public GameObject focus;
    public Text[] textNumbers = new Text[5];

    public bool isActivated;

    private int focusNumber=-2;
    private int[] numbers = new int[5];
    private bool playerInArea;
    private bool openDoor=false;

    void Start () {
        HelpText.SetActive(false);
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = 0;
    }
	
	void Update () {
        if (openDoor)
        {
            door.transform.Rotate(Vector3.left * Time.deltaTime * 20);
            if (door.transform.rotation.x < -0.9999) openDoor = false;
        }
        if (isActivated && playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                if (safeCanvas.enabled)
                    hideCanvas();
                else
                    showCanvas();
            }
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                if(numbers[0]==2 && numbers[1] == 3 && numbers[2] == 1 && numbers[3] == 0 && numbers[4] == 6)
                {
                    isActivated = false;
                    openDoor = true;
                    hideCanvas();
                }
            }


                if (Input.GetKeyDown(KeyCode.RightArrow) && focusNumber<2)
            {
                focusNumber++;
                focus.GetComponent<RectTransform>().localPosition = new Vector3(300 * focusNumber, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && focusNumber > -2)
            {
                focusNumber--;
                focus.GetComponent<RectTransform>().localPosition = new Vector3(300 * focusNumber, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && numbers[focusNumber + 2] < 9)
            {
                numbers[focusNumber + 2]++;
                textNumbers[focusNumber + 2].text = numbers[focusNumber + 2].ToString();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && numbers[focusNumber + 2] > 0)
            {
                numbers[focusNumber + 2]--;
                textNumbers[focusNumber + 2].text = numbers[focusNumber + 2].ToString();
            }
        }
     }

    private void showCanvas()
    {
        safeCanvas.enabled = true;
        player.GetComponent<PlayerMovement>().enabled=false;
        HelpText.SetActive(false);
    }

    private void hideCanvas()
    {
        safeCanvas.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        if(isActivated)
            HelpText.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isActivated)
                HelpText.SetActive(true);
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HelpText.SetActive(false);
            playerInArea = false;
        }
    }
}
