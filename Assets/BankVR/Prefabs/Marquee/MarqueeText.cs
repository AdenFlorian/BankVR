using UnityEngine;
using System.Collections;

public class MarqueeText : MonoBehaviour {

    public GameObject thingToScroll;

    [Range(0.0f, 100.0f)]
    public float scrollSpeed = 1.0f;
    public float startRightPosX = 1.0f;
    public float endLeftPosX = -1.0f;
    
	void Start() {
        Vector3 newPos = thingToScroll.transform.position;
        newPos.x = startRightPosX;
        thingToScroll.transform.position = newPos;
	}
	
	void Update() {
        Vector3 newPos = thingToScroll.transform.position;
        newPos.x -= (scrollSpeed * Time.deltaTime);
        if (newPos.x < endLeftPosX) {
            newPos.x = startRightPosX;
        }
        thingToScroll.transform.position = newPos;
    }
}
