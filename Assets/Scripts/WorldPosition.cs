using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    private Vector3 position;

    public float x, y, z;

    private void Start()
    {
        position = new Vector3(x, y, z);
    }

    private void LateUpdate()
    {
        transform.position = position;
    }
}
