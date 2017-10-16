using UnityEngine;
using System.Collections;

public class HudManager : MonoBehaviour {
    public GameObject TrackingTarget;
    public GameObject MinimapCamera;
    public GameObject HUDDisplay;
    public float ActivateHUDThresholdMin;
    public float ActivateHUDThresholdMax;


    void Update() {
        UpdateActiveStatus(MinimapCamera);
        UpdateActiveStatus(HUDDisplay);

        if(gameObject.activeSelf) {
            transform.rotation = Quaternion.LookRotation(transform.position - TrackingTarget.transform.position);
            transform.position = new Vector3(
                Mathf.Sin(TrackingTarget.transform.localEulerAngles.y * Mathf.Deg2Rad) + TrackingTarget.transform.position.x,
                gameObject.transform.position.y,
                Mathf.Cos(TrackingTarget.transform.localEulerAngles.y * Mathf.Deg2Rad) + TrackingTarget.transform.position.z
                );
        }        
    }

    private void UpdateActiveStatus(GameObject gameObjectToUpdate) {
        if (TrackingTarget != null) {
            if (TrackingTarget.transform.localEulerAngles.x >= ActivateHUDThresholdMin && TrackingTarget.transform.localEulerAngles.x <= ActivateHUDThresholdMax) {
                if (!gameObjectToUpdate.activeSelf) {
                    gameObjectToUpdate.SetActive(true);
                }
            } else {
                if (gameObjectToUpdate.activeSelf) {
                    gameObjectToUpdate.SetActive(false);
                }
            }
        }
    }
}
