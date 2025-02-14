using System.Collections;
using TMPro;
using UnityEngine;

public class WallerPoints : MonoBehaviour {
    [SerializeField] private GameObject text;
    [SerializeField] private float turnSpeed = 0.0f;
    [SerializeField] public int y;

    //Starts rotation
    private void Awake() {
        StartCoroutine(Rotate());
    }

    //Changes the y position based on the settings of the control panel
    private void Update() {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    //Rotates balls slowly
    private IEnumerator Rotate() {
        while (true) {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + turnSpeed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    //Getters/setters
    public void SetText() {
        text.GetComponent<TextMeshProUGUI>().text = y.ToString();
    }

    public void SetY(int y) {
        this.y = y;
    }

    public void AddY(int y) {
        this.y += y;
    }

    public int GetY() { 
        return this.y;
    }
}
