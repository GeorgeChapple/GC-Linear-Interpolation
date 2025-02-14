using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallerLerpPlane : MonoBehaviour
{
    [SerializeField] private GameObject lerpObject;
    [SerializeField] private GameObject lerpMidPoint;
    [SerializeField] private GameObject lerpEndPoint;
    bool placePointState = false;

    //When player clicks floor, alternate which point to place and then place that point there
    public void ChangePoints() {
        if (placePointState) {
            lerpMidPoint.transform.position = new Vector3(GetComponent<EventInput>().hitCoords.x, lerpMidPoint.transform.position.y, GetComponent<EventInput>().hitCoords.z);
        } else {
            lerpEndPoint.transform.position = new Vector3(GetComponent<EventInput>().hitCoords.x, lerpEndPoint.transform.position.y, GetComponent<EventInput>().hitCoords.z);
        }
        placePointState = !placePointState;
    }

}
