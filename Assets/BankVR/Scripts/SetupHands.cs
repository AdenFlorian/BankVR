using UnityEngine;
using System.Collections;

public class SetupHands : MonoBehaviour {

    public GameObject controllerLeftGO;
    public GameObject controllerRightGO;
    public GameObject handPrefab;
    
    void Start () {
        GameObject handLeftGO = Instantiate<GameObject>(handPrefab);
        GameObject handRightGO = Instantiate<GameObject>(handPrefab);
        handLeftGO.transform.position = controllerLeftGO.transform.position;
        handRightGO.transform.position = controllerRightGO.transform.position;
        handLeftGO.GetComponent<Hand>().SetTarget(controllerLeftGO.transform);
        handRightGO.GetComponent<Hand>().SetTarget(controllerRightGO.transform);
    }
    
    void Update () {
	
	}
}
