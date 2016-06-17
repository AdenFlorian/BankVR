using UnityEngine;
using System.Collections;

public class VRRichLever : MonoBehaviour {

    public float rotationTriggerAMax = 60f;
    public float rotationTriggerAMin = 10f;
    public float rotationTriggerBMax = 350f;
    public float rotationTriggerBMin = 300f;

    LeverTrigger lastTrigger = LeverTrigger.A;

    enum LeverTrigger {
        A,
        B
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (lastTrigger == LeverTrigger.A) {
            if (transform.rotation.eulerAngles.z < rotationTriggerBMax
                && transform.rotation.eulerAngles.z > rotationTriggerBMin) {
                OnTriggerB();
            }
        } else if (lastTrigger == LeverTrigger.B) {
            if (transform.rotation.eulerAngles.z < rotationTriggerAMax
                && transform.rotation.eulerAngles.z > rotationTriggerAMin) {
                OnTriggerA();
            }
        } else {
            throw new System.Exception("wat");
        }
    }

    void OnTriggerA() {
        Debug.Log("Lever Trigger A");
        lastTrigger = LeverTrigger.A;
    }

    void OnTriggerB() {
        Debug.Log("Lever Trigger B");
        lastTrigger = LeverTrigger.B;
    }
}
