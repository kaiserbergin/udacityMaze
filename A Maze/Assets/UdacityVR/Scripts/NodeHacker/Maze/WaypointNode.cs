using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour {
    public GameObject waypointCollider;
    public void TeleportPlayerToWaypointNode()
    {
        Camera.main.transform.parent.transform.position = gameObject.transform.position;
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
