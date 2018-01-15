using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossEnter : MonoBehaviour {

    public GameObject WielkieKowadlo;
    public bool wielkieKowadloIsDropping;
    private bool playerInArea;
    private float droppingSpeed = 10f; 

    // Update is called once per frame
    void Update()
    {
        if (wielkieKowadloIsDropping == true)
        {
            WielkieKowadlo.transform.Translate(Vector3.down * Time.deltaTime * droppingSpeed);
        }
        if (WielkieKowadlo.transform.position.y < 0f)
        {
            wielkieKowadloIsDropping = false;
            WielkieKowadlo.GetComponent<Demage>().StopDoingDemage();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            wielkieKowadloIsDropping = true;
        }
    }
}
