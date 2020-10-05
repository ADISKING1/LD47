using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
