using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTemplate : MonoBehaviour
{
    [SerializeField] private float steeringSpeed;
    [SerializeField] private float steeringSide; //value ranging from -1 to 1, -1 means full steer to the left, 1 means full steer to the right, 0 means no steering
    [SerializeField] private float forwardSpeed;
    public Vector2 allocatedManouverability; //how much the ship can rotate / go forward, the sum of these 2 cannot be greater than 1
    [SerializeField] private Transform selfTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.Translate(selfTransform.forward * 0.1f * forwardSpeed);
        //selfTransform.Rotate(selfTransform.forward * 0.1f * steeringSpeed);
        selfTransform.transform.Rotate(new Vector3(0f, 0f, steeringSpeed * steeringSide), Space.Self);

        //forwards
        // && steeringSpeed + forwardSpeed <= 1)
        if (Input.GetKey(KeyCode.W) && forwardSpeed < 1)
        {
            if (steeringSpeed + forwardSpeed >= 1 && steeringSpeed >= 0f)//exchange torque for speed
            {
                float change = 1f * Time.deltaTime;
                steeringSpeed -= change;
                steeringSide = steeringSpeed;
                forwardSpeed += change;
            }
            else if (steeringSpeed + forwardSpeed <= 1)
            {
                forwardSpeed += 1f * Time.deltaTime;
                print(forwardSpeed);
            }
            if (forwardSpeed > 1) //make sure that the ship doesn't exceed the max speed
            {
                forwardSpeed = 1;
            }
        }
        else if (Input.GetKey(KeyCode.S) && forwardSpeed > 0)
        {
            forwardSpeed -= 1f * Time.deltaTime;
            if (forwardSpeed < 0) //make sure that the ship doesn't slowly drift backwards
            {
                forwardSpeed = 0;
            }
            print(forwardSpeed);
        }

        //turning 
        if (Input.GetKey(KeyCode.D) && steeringSide <= 1f)//right
        {
            steeringSide += 1f * Time.deltaTime;

            if (steeringSide > 0)
            {
                steeringSpeed = steeringSide;
                if (steeringSpeed + forwardSpeed >= 1)
                {
                    steeringSpeed = steeringSide;
                    forwardSpeed -= Time.deltaTime;
                }
            }
            if (steeringSide > 1) //make sure that the ship doesn't exceed steering limits
            {
                steeringSide = 1;
            }
            //if (steeringSide < 0)
            //{
            //    steeringSide = 0;
            //}
            //if (steeringSpeed + forwardSpeed >= 1 && forwardSpeed >= 0f)//exchange speed for torque
            //{
            //    float change = 1f * Time.deltaTime;
            //    forwardSpeed -= change;
            //    steeringSpeed += change;
            //}
            //else if (steeringSpeed + forwardSpeed <= 1)
            //{
            //    steeringSpeed += 1f * Time.deltaTime;
            //    print(steeringSpeed);
            //}
        }

        if (Input.GetKey(KeyCode.A) && steeringSide >= -1f)//left
        {
            steeringSide -= 1f * Time.deltaTime;

            if (steeringSide < 0)
            {
                steeringSpeed = -steeringSide;
                if (steeringSpeed + forwardSpeed >= 1)
                {
                    steeringSpeed = -steeringSide;
                    forwardSpeed -= Time.deltaTime;
                }
            }
            if (steeringSide <= -1) //make sure that the ship doesn't exceed steering limits
            {
                steeringSide = -1;
            }
            //if (steeringSide > 0)
            //{
            //    steeringSide = 0;
            //}
            //if (steeringSpeed + forwardSpeed >= 1 && forwardSpeed >= 0f)//exchange speed for torque
            //{
            //    float change = 1f * Time.deltaTime;
            //    forwardSpeed -= change;
            //    steeringSpeed += change;
            //}

            //if (steeringSpeed + forwardSpeed >= 1 && forwardSpeed >= 0f)//exchange speed for torque
            //{
            //    float change = 1f * Time.deltaTime;
            //    forwardSpeed -= change;
            //    steeringSpeed += change;
            //}
            //else if (steeringSpeed + forwardSpeed <= 1)
            //{
            //    steeringSpeed += 1f * Time.deltaTime;
            //    print(steeringSpeed);
            //}
        }

        //else if (Input.GetKey(KeyCode.A) && steeringSpeed > 0)
        //{
        //    steeringSpeed -= 1f * Time.deltaTime;
        //    if (steeringSpeed < 0) //make sure that the ship doesn't slowly turn constantly
        //    {
        //        steeringSpeed = 0;
        //    }
        //    print(steeringSpeed);
        //}
    }
}