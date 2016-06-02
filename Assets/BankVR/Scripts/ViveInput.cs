using UnityEngine;
using System.Collections;

public class ViveInput : MonoBehaviour {

    public static ViveInput Instance;

    public SteamVR_TrackedObject LeftControllerTrackedObj;
    public SteamVR_TrackedObject RightControllerTrackedObj;

    public bool leftTriggerTouch = false;
    public bool rightTriggerTouch = false;
    public bool leftPadTouch = false;
    public bool rightPadTouch = false;

    // Use this for initialization
    void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        // Reset trigger touches
        leftTriggerTouch = false;
        rightTriggerTouch = false;
        leftPadTouch = false;
        rightPadTouch = false;


    SteamVR_Controller.Device deviceLeft = null;
        SteamVR_Controller.Device deviceRight = null;
        try {
            deviceLeft = SteamVR_Controller.Input((int)LeftControllerTrackedObj.index);
            deviceRight = SteamVR_Controller.Input((int)RightControllerTrackedObj.index);
        } catch (System.IndexOutOfRangeException) {
            // Not sure what to do with this yet, only happens on first update
            //Debug.Log("IndexOutOfRangeException");
            return;
        }


        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
        //    Debug.Log("Holding 'Touch' on Trigger");
        //}

        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Did 'TouchDown' on left Trigger");
            leftTriggerTouch = true;
        }
        if (deviceRight.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Did 'TouchDown' on right Trigger");
            rightTriggerTouch = true;
        }
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Did 'TouchDown' on left Touchpad");
            leftPadTouch = true;
        }
        if (deviceRight.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Did 'TouchDown' on right Touchpad");
            rightPadTouch = true;
        }
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Did 'PressDown' on left Touchpad");
        }
        if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("Did 'PressDown' on right Touchpad");
        }
    }
}
