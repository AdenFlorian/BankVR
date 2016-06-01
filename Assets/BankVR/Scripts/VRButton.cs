using UnityEngine;
using System.Collections;

public class VRButton : MonoBehaviour {

    public ButtonHolder buttonHolder;
    public Vector3 maxLocalPosition;
    public Vector3 minLocalPosition;
    public Vector3 targetLocalPosition;
    public float forceMulti = 1f;

    new Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        targetLocalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Need to constrain it's position along a line
        Vector3 startLocalPos = transform.localPosition;
        Vector3 newPos = startLocalPos;
        //newPos.y = -newPos.z;
        //transform.localPosition = newPos;



        if (startLocalPos.x > maxLocalPosition.x) {
            newPos.x = maxLocalPosition.x;
        } else if (startLocalPos.x < minLocalPosition.x) {
            newPos.x = minLocalPosition.x;
            OnPressed();
        }
        if (startLocalPos.y > maxLocalPosition.y) {
            newPos.y = maxLocalPosition.y;
        } else if (startLocalPos.y < minLocalPosition.y) {
            newPos.y = minLocalPosition.y;
            OnPressed();
        }
        if (startLocalPos.z > maxLocalPosition.z) {
            newPos.z = maxLocalPosition.z;
        } else if (startLocalPos.z < minLocalPosition.z) {
            newPos.z = minLocalPosition.z;
            OnPressed();
        }

        //transform.localPosition = newPos;
        rigidbody.MovePosition(transform.parent.localToWorldMatrix.MultiplyPoint(newPos));

        Vector3 currentToTargetVec = (targetLocalPosition - startLocalPos).normalized;
        rigidbody.AddForce(currentToTargetVec * forceMulti * Time.fixedDeltaTime);
    }

    void OnPressed() {
        buttonHolder.OnButtonPress();
    }
}
