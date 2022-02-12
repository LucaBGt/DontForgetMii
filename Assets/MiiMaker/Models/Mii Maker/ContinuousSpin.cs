using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousSpin : MonoBehaviour
{
    public Vector3 SpinVector = new Vector3(0, 1, 0);

    private void FixedUpdate()
    {
        transform.Rotate(SpinVector);
    }
}
