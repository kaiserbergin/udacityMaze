using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncryptedKey : Item {
    public float spinSpeedMultiplier = 10f;

    public bool IsDecrypted;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime);
    }
}
