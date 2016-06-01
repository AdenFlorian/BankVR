using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Hand : MonoBehaviour {

    Transform targetController;
    new Rigidbody rigidbody;
    
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        DoPosition();
        DoRotation();
    }

    public void SetTarget(Transform target) {
        targetController = target;
    }

    private void DoPosition() {
        // Get vector from current position to parent's position
        Vector3 forceToParentPosition = targetController.position - transform.position;

        // Divide by fixed timestep (default is 0.2f)
        // so that we will get where we want to go in one step
        forceToParentPosition = forceToParentPosition / Time.fixedDeltaTime;

        // Subtract existing velocity
        forceToParentPosition = forceToParentPosition - rigidbody.velocity;

        // Add force as a VelocityChange, so it ignores mass, and effectively just sets our velocity
        rigidbody.AddForce(forceToParentPosition, ForceMode.VelocityChange);
    }

    private void DoRotation() {
        rigidbody.rotation = targetController.rotation;
    }
}
