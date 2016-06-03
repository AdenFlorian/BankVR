using UnityEngine;
using System.Collections;

public class TeleportSpot : MonoBehaviour {

    public float highlightScaleMulti = 2f;
    Vector3 originalScale;

	// Use this for initialization
	void Start () {
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = originalScale;
    }

    public void HighlightOn() {
        transform.localScale = originalScale * highlightScaleMulti;
        Debug.Log("TeleSpot Highlighted!");
    }
}
