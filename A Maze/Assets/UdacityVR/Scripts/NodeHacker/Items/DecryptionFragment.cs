using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecryptionFragment : Item {
    public float spinSpeedMultiplier = 10f;

    void Update() {
        transform.Rotate(Vector3.up, spinSpeedMultiplier * Time.deltaTime * -1);
    }

}
