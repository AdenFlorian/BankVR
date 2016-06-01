using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

    public SteamVR_TrackedObject LeftControllerTrackedObj;
    public SteamVR_TrackedObject RightControllerTrackedObj;
    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device deviceLeft = null;
        SteamVR_Controller.Device deviceRight = null;
        try {
            deviceLeft = SteamVR_Controller.Input((int)LeftControllerTrackedObj.index);
            deviceRight = SteamVR_Controller.Input((int)RightControllerTrackedObj.index);
        } catch (System.IndexOutOfRangeException) {
            // Not sure what to do with this yet, only happens on first update
            Debug.Log("IndexOutOfRangeException");
            return;
        }


        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
        //    Debug.Log("Holding 'Touch' on Trigger");
        //}

        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Did 'TouchDown' on left Trigger");
            SpawnBall();
        }
        if (deviceRight.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Did 'TouchDown' on right Trigger");
            SpawnBall();
        }
    }

    void SpawnBall() {
        GameObject newBallGO = Instantiate<GameObject>(ballPrefab);
        newBallGO.transform.position = transform.position;
    }
}
