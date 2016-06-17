using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class VRGrabbable : MonoBehaviour {

    bool grabbed = false;
    VRGrabber grabbedBy = null;

    public Transform target;
    new Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	void Update() {
        if (grabbed && grabbedBy != null) {
            transform.position = grabbedBy.transform.position;
        }
	}

    public VRGrabbable Grab(VRGrabber grabber) {
        if (grabbed) {
            if (grabbedBy != null) {
                // Inform current grabber that it is not grabbing us anymore
                grabbedBy.OnGrabbedAway();
            } else {
                throw new System.Exception("grabbedBy was null but grabbed was true!");
            }
        }
        
        grabbedBy = grabber;
        grabbed = true;

        return this;
    }

    public void LetItGo() {
        if (grabbed == false) {
            throw new System.Exception("Let what go?!?!");
        }
        if (grabbedBy == null) {
            throw new System.Exception("Who are you! Nobody is grabbing me! WHAT IS THIS!");
        }
        grabbed = false;
        grabbedBy = null;
    }

    public void OnHighlighted() {

    }

    public void HighlightOff() {

    }

    void FixedUpdate() {
        if (target != null) {
            DoPosition();
        }
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }

    private void DoPosition() {
        // Get vector from current position to parent's position
        Vector3 forceToParentPosition = target.position - transform.position;

        // Divide by fixed timestep (default is 0.2f)
        // so that we will get where we want to go in one step
        forceToParentPosition = forceToParentPosition / Time.fixedDeltaTime;

        // Subtract existing velocity
        forceToParentPosition = forceToParentPosition - rigidbody.velocity;

        // Add force as a VelocityChange, so it ignores mass, and effectively just sets our velocity
        rigidbody.AddForce(forceToParentPosition, ForceMode.VelocityChange);
    }
}
