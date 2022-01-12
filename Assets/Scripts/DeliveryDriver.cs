using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDriver : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4.0f;
    [SerializeField]
    float boostSpeed = 5.0f;
    [SerializeField]
    float slowSpeed = 3.0f;
    [SerializeField]
    float steerSpeed = 60.0f;

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical");
        float steerAmount = Input.GetAxis("Horizontal");

        transform.Translate(0, moveSpeed * moveAmount * Time.deltaTime, 0);
        transform.Rotate(0, 0, steerSpeed * -steerAmount * Time.deltaTime);
    }   // Update()

    public void hitBump()
    {
        moveSpeed = slowSpeed;
    }   // hitBump()

    public void hitBoost()
    {
		moveSpeed = boostSpeed;
    }   // hitBoost()
}   // class DeliveryDriver