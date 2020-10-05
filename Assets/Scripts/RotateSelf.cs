using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour
{
    public int rotateSpeed = 30;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);

    }
}