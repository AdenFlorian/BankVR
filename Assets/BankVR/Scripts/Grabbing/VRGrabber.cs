using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public class VRGrabber : MonoBehaviour {

    VRGrabbable grabbedObject = null;
    VRGrabbable highlightedGrabbableObject = null;
    bool canGrabSomething = true;
    
	void Start() {
	
	}
	
	void Update() {
        if (CheckGrabInput()) {
            TryToGrabHighlightedGrabbable();
        } else if (CheckLetGoInput()) {
            TryToLetGoOfGrabbedObject();
        }
	}

    public void OnGrabbedAway() {
        Debug.Log("Who took my crabapple!?");
    }

    void OnTriggerEnter(Collider other) {
        // Check if other is a VRGrabbable
        var grabbable = other.GetComponent<VRGrabbable>();
        if (grabbable != null) {
            // If it is, highlight it
            TryToSetHighlightedGrabbable(grabbable);
        }
    }

    void OnTriggerExit(Collider other) {
        // Check if we exited the current highlighted grabbable's collider
        var grabbable = other.GetComponent<VRGrabbable>();
        if (grabbable == null) { return; }
        if (grabbable == highlightedGrabbableObject) {
            // Then unset it
            UnsetHighlightedGrabbable(grabbable);
        }
    }

    void TryToGrabHighlightedGrabbable() {
        if (highlightedGrabbableObject == null) {
            Debug.Log("You are grabbing at air...");
            return;
        }

        if (canGrabSomething == false) {
            Debug.Log("YOU...SHALL NOT....GRAB!!!");
            return;
        }

        var grabbedObjectMaybe = highlightedGrabbableObject.Grab(this);
        if (grabbedObjectMaybe == null) {
            Debug.LogWarning("Failed to Grab :(");
        } else {
            grabbedObject = grabbedObjectMaybe;
            OnGrabbedSomething();
        }
    }

    void OnGrabbedSomething() {
        canGrabSomething = false;
    }

    void OnLetGo() {
        canGrabSomething = true;
    }

    void TryToLetGoOfGrabbedObject() {
        if (grabbedObject == null) {
            Debug.Log("Nothing to let go of...how sad :(");
            return;
        }
        grabbedObject.LetItGo();
        grabbedObject = null;
        OnLetGo();
    }

    void TryToSetHighlightedGrabbable(VRGrabbable grabbable) {
        // Check if we already have a highlighted grabbable
        if (highlightedGrabbableObject != null) {
            // If we do, unhighlight it
            UnsetHighlightedGrabbable(grabbable);
        }

        highlightedGrabbableObject = grabbable;
        grabbable.OnHighlighted();
    }

    void UnsetHighlightedGrabbable(VRGrabbable grabbable) {
        highlightedGrabbableObject = null;
        grabbable.HighlightOff();
    }

    //IEnumerator UnsetHighlightedGrabbable() {
    //    yield return new WaitForEndOfFrame();
    //    highlightedGrabbableObject.HighlightOff();
    //    highlightedGrabbableObject = null;
    //}

    bool CheckGrabInput() {
        if (Input.GetMouseButtonDown(0)) {
            return true;
        }

        return false;
    }

    bool CheckLetGoInput() {
        if (Input.GetMouseButtonDown(1)) {
            return true;
        }

        return false;
    }


}
