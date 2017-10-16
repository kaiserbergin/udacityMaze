using UnityEngine;
using System.Collections;

public class MinimapPlayerIconRotation : MonoBehaviour {
    public GameObject TrackingTarget;
    private Vector3 originalEulers;
    private void Awake() {
        originalEulers = gameObject.transform.localEulerAngles;
    }
    // Update is called once per frame
    void Update() {
        gameObject.transform.localEulerAngles = new Vector3(
            originalEulers.x,
            TrackingTarget.transform.localEulerAngles.y,
            originalEulers.z
        );
    }
}
