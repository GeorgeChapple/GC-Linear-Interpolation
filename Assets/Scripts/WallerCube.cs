using TMPro;
using UnityEngine;

public class WallerCube : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject midPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject text;

    //Moves the starting marker to its current position
    //Sets the start point, mid point and end point for a lerp
    //Starts a bezier lerp based on the markers
    public void StartLerpBezier() {
        if (!GetComponent<LerpScript>().lerping) {
            startPoint.transform.position = transform.position;
            GetComponent<LerpScript>().startingValueV = transform.position;
            GetComponent<LerpScript>().midValueV = midPoint.transform.position;
            GetComponent<LerpScript>().endingValueV = endPoint.transform.position;
            GetComponent<LerpScript>().StartBezierLerpV();
        }
    }

    //Displays the current time to take on the panel
    public void ChangeText() {
        text.GetComponent<TextMeshProUGUI>().text = GetComponent<LerpScript>().timeToTake.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetComponent<LerpScript>().lerpVector; //Update current position based on lerp
        if (Input.GetKeyDown(KeyCode.E)) {
            StartLerpBezier(); //If e key pressed, start lerp
        }
    }
}
