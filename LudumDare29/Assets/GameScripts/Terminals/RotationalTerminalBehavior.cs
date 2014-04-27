using UnityEngine;
using System.Collections;

public class RotationalTerminalBehavior : MonoBehaviour
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior PlayerObject;
    public float DistanceFrom = .5f;
    public float RotationStrength = 1;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.SqrMagnitude(PlayerObject.transform.position - this.transform.position) < DistanceFrom)
        {
            if (Input.GetKey(KeyCode.E))
                PlayerShipPhysics.dirDeg -= RotationStrength * Time.deltaTime;
            else if (Input.GetKey(KeyCode.Q))
                PlayerShipPhysics.dirDeg += RotationStrength * Time.deltaTime;
        }
    }
}
