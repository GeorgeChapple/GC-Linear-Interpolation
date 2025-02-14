using TMPro;
using UnityEngine;

public class EnumButton : MonoBehaviour
{
    [SerializeField] private GameObject dropDown;
    [SerializeField] private GameObject lerpObject;

    //When arrows on panel are pressed, change ease of the Lerp object
    public void ChangeButtonValue(int input) {
        dropDown.GetComponent<TMP_Dropdown>().value += input;
        if (dropDown.GetComponent<TMP_Dropdown>().value == 0) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeLinear;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 1) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInQuad;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 2) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeOutQuad;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 3) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInOutQuad;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 4) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInSine;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 5) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeOutSine;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 6) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInOutSine;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 7) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInCubic;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 8) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeOutCubic;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 9) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInOutCubic;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 10) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInExpo;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 11) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeOutExpo;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 12) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInOutExpo;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 13) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInBounce;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 14) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeOutBounce;
        } else if (dropDown.GetComponent<TMP_Dropdown>().value == 15) {
            lerpObject.GetComponent<LerpScript>().myEase = LerpScript.eases.easeInOutBounce;
        }
    }
}
