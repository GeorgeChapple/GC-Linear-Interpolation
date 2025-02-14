using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInput : MonoBehaviour
{
    [SerializeField ]private UnityEvent raycastHitEvent;
    public Vector3 hitCoords;

    //Calls event for when a raycast hits an object with this script
    public void raycastHitThisThing() {
        raycastHitEvent.Invoke();
    }
}
