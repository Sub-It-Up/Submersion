using UnityEngine;
using System.Collections;

public class BalistTerminalBehavior : MonoBehaviour 
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior[] PlayerObject;
    public float DistanceFrom = .5f;
    public float BalistStrength = 1;

    // Update is called once per frame
    void Update()
    {
      for (int i = 0; i < 2; ++i)
      {
        if (Vector2.SqrMagnitude(PlayerObject[i].transform.position - this.transform.position) < DistanceFrom)
        {
          if (Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0)
                PlayerShipPhysics.balist += BalistStrength * Time.deltaTime;
          else if (Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0)
                PlayerShipPhysics.balist -= BalistStrength * Time.deltaTime;
        }
      }
    }
}
