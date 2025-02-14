using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Lerps this object's rotation and size, flinging attatched ball around
        GetComponent<LerpScript>().startingValueV = new Vector3(1, 1, 1);
        GetComponent<LerpScript>().endingValueV = new Vector3(transform.localScale.x + 1, transform.localScale.x + 1, transform.localScale.x + 1);
        GetComponent<LerpScript>().StartLerpV();
        transform.localScale = GetComponent<LerpScript>().lerpVector;
        transform.eulerAngles = GetComponent<LerpScript>().lerpVector * 360;
    }
}
