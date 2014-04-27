using UnityEngine;
using System.Collections;

public class ThrustTerminalBehavior : MonoBehaviour
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior PlayerObject;
    public float DistanceFrom = .5f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.SqrMagnitude(PlayerObject.transform.position - this.transform.position) < DistanceFrom
            && Input.GetKeyDown(KeyCode.E))
        {
            PlayerShipPhysics.thrust += Time.deltaTime;
        }
    }
}
