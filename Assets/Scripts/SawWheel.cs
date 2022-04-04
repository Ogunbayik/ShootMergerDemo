using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWheel : MonoBehaviour
{
    [Header("Wheel Settings")]
    [Range(5,10)]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotateAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotateAngle, rotationSpeed * Time.deltaTime);
    }
}
