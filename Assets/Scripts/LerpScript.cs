using System.Collections;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    public bool lerping = false;
    public float lerpFloat;
    public Vector3 lerpVector;
    [SerializeField] public float startingValueF;
    [SerializeField] public float endingValueF;
    [SerializeField] public Vector3 startingValueV;
    [SerializeField] public Vector3 midValueV;
    [SerializeField] public Vector3 endingValueV;
    [SerializeField] public float timeToTake = 1f;

    //Enum used to select current ease
    public enum eases {
        easeLinear,
        easeInQuad, easeOutQuad, easeInOutQuad,
        easeInSine, easeOutSine, easeInOutSine, 
        easeInCubic, easeOutCubic, easeInOutCubic,
        easeInExpo, easeOutExpo, easeInOutExpo,
        easeInBounce, easeOutBounce, easeInOutBounce
    }

    public eases myEase; //Stores current ease

    //Starts a float based lerp
    public void StartLerpF() {
        if ( lerping == false ) {
            lerping = true;
            StartCoroutine( LerpFloat( myEase , startingValueF, endingValueF));
        }
    }

    //Starts a vector based lerp
    public void StartLerpV() {
        if (lerping == false) {
            lerping = true;
            StartCoroutine(LerpVector3(myEase, startingValueV, endingValueV));
        }
    }

    //Starts a Bezier vector based lerp
    public void StartBezierLerpV() {
        if (lerping == false) {
            lerping =true;
            StartCoroutine(BezierVector3(myEase, startingValueV, endingValueV, midValueV));
        }
    }

    //Performs the desired ease calculation
    //2025 Jimbo will update this to not be a horrible else if statement and instead use delegates soon
    public float GetEase(eases ease, float time) {
        float perc = 0;
        if (ease == eases.easeLinear) {
            perc = Easing.Linear(time);
        } else if (ease == eases.easeInQuad) {
            perc = Easing.Quad.In(time);
        } else if (ease == eases.easeOutQuad) {
            perc = Easing.Quad.Out(time);
        } else if (ease == eases.easeInOutQuad) {
            perc = Easing.Quad.InOut(time);
        } else if (ease == eases.easeInSine) {
            perc = Easing.Sine.In(time);
        } else if (ease == eases.easeOutSine) {
            perc = Easing.Sine.Out(time);
        } else if (ease == eases.easeInOutSine) {
            perc = Easing.Sine.InOut(time);
        } else if (ease == eases.easeInCubic) {
            perc = Easing.Cubic.In(time);
        } else if (ease == eases.easeOutCubic) {
            perc = Easing.Cubic.Out(time);
        } else if (ease == eases.easeInOutCubic) {
            perc = Easing.Cubic.InOut(time);
        } else if (ease == eases.easeInExpo) {
            perc = Easing.Expo.In(time);
        } else if (ease == eases.easeOutExpo) {
            perc = Easing.Expo.Out(time);
        } else if (ease == eases.easeInOutExpo) {
            perc = Easing.Expo.InOut(time);
        } else if (ease == eases.easeInBounce) {
            perc = Easing.Bounce.In(time);
        } else if (ease == eases.easeOutBounce) {
            perc = Easing.Bounce.Out(time);
        } else if (ease == eases.easeInOutBounce) {
            perc = Easing.Bounce.InOut(time);
        }
        return perc;
    }

    //Float based lerp
    IEnumerator LerpFloat( eases ease, float start, float end)
    {
        float time = 0;
        float timeTaken = 0;
        float perc = 0;
        //Lerp between 0 and 1
        while ( time < 1 ) {
            perc = GetEase(ease, time);
            lerpFloat = LerpF(start, end, perc);
            timeTaken += Time.deltaTime;
            time = timeTaken / timeToTake; //Allows for time to lerp to be changed
            yield return null;
        }
        lerping = false;
    }

    //Vector based lerp, same as float
    IEnumerator LerpVector3(eases ease, Vector3 start, Vector3 end) {
        float time = 0;
        float timeTaken = 0;
        float perc = 0;
        while (time < 1) {
            perc = GetEase(ease, time);
            lerpVector = LerpV(start, end, perc);
            timeTaken += Time.deltaTime;
            time = timeTaken / timeToTake;
            yield return null;
        }
        lerping = false;
    }

    //Vector based Bezier
    IEnumerator BezierVector3(eases ease, Vector3 start, Vector3 end, Vector3 mid) {
        float time = 0;
        float timeTaken = 0;
        float perc = 0;
        while (time < 1) {
            perc = GetEase(ease, time);
            //Lerp between the 3 points and then lerp those 2 lerps
            Vector3 mid1 = LerpV(start, mid, perc);
            Vector3 mid2 = LerpV(mid, end, perc);
            lerpVector = LerpV(mid1, mid2, perc);
            timeTaken += Time.deltaTime;
            time = timeTaken / timeToTake;
            yield return null;
        }
        lerping = false;
    }

    //FLoat lerp function
    public static float LerpF( float startValue, float endValue, float t ) {
        return ( startValue + ( endValue - startValue ) * t );
    }

    //Vector lerp function
    public static Vector3 LerpV (Vector3 startValue, Vector3 endValue, float t ) {
        return (startValue + ( endValue - startValue ) * t);
    }

    //Getters and setters
    public void ChangeTime(float time) {
        timeToTake += time;
    }

    public void SetTime(float time) { 
        timeToTake = time;
    }

    public float GetTime() {
        return timeToTake;
    }
}
