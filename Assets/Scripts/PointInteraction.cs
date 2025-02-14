using UnityEngine;
using UnityEngine.InputSystem;

public class PointInteraction : MonoBehaviour
{
    [SerializeField] private InputActionReference playerInputs;
    private float pointerInputValue;
    private bool shoot;
    private Camera cam;
    private Vector3 lerpCoords;

    //Updates pointerInputValue with float value based on current state of mouse button 1
    void Awake() {
        playerInputs.action.performed += context => pointerInputValue = context.action.ReadValue<float>();  
    }

    //Sets camera to cast raycast from
    void Start() {
        cam = Camera.main;
    }

    //Update is called once per frame
    void Update() {
        //Runs shoot function when mouse button 1 has been pressed
        if (pointerInputValue == 1) {
            if (shoot == false) {
                Shoot();
            }
        } else if (pointerInputValue == 0) {
            shoot = false;
        }
    }

    //Shoot a raycast
    void Shoot() {
        shoot = true;
        RaycastHit hit;
        //Checks to see if raycast hit anything
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100f)) {
            Debug.Log("Shot" + hit.transform.name);
            //Try to find EventInput script
            try {
                //If found, trigger event and give hit.point to the script
                hit.collider.gameObject.GetComponent<EventInput>().hitCoords = hit.point;
                hit.collider.gameObject.GetComponent<EventInput>().raycastHitThisThing();
            } catch {
                //If not, log debug
                Debug.Log("No interaction available...");
            }
        }
    }
}
