using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour {
    public GameObject waypointCollider;
    public void TeleportPlayerToWaypointNode()
    {
        Camera.main.transform.parent.transform.position = new Vector3(
            gameObject.transform.position.x,
            Camera.main.transform.parent.transform.position.y,
            gameObject.transform.position.z
        );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (waypointCollider != null)
        {
            if (other.tag == "Player")
            {
                waypointCollider.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (waypointCollider != null)
        {
            if (other.tag == "Player")
            {
                waypointCollider.SetActive(false);
            }
        }
    }    
}
