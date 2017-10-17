using System;
using System.Collections.Generic;
using UnityEngine;

public class BitCoin : Item {
    public GameObject CoinCollider;
    public float spinSpeedMultiplier = 10f;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (CoinCollider != null) {
            if (other.tag == "Player") {
                Collider ownCollider = gameObject.GetComponent<Collider>();
                ownCollider.enabled = false;
                CollectItem();
            }
        }

    }
}
