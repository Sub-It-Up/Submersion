using UnityEngine;
using System.Collections;

public class ThrustTerminalBehavior : MonoBehaviour
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior[] PlayerObject;
    public float DistanceFrom = .5f;
    public float ThrustStrength = 1;

    public Sprite DeActiveThruster;
    public Sprite ActiveThruster;

    private SpriteRenderer thrustTerminal;

    void Start()
    {
        thrustTerminal = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool[] activeButtons = { false, false };

        for (int i = 0; i < 2; ++i)
        {
            if (Vector2.SqrMagnitude(PlayerObject[i].transform.position - this.transform.position) < DistanceFrom)
            {
                if (Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0)
                {
                    if (thrustTerminal.sprite != ActiveThruster)
                        thrustTerminal.sprite = ActiveThruster;

                    PlayerShipPhysics.thrust += ThrustStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
                else if (Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0)
                {
                    if (thrustTerminal.sprite != ActiveThruster)
                        thrustTerminal.sprite = ActiveThruster;

                    PlayerShipPhysics.thrust -= ThrustStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
            }
        }

        if (activeButtons[0] == false && activeButtons[1] == false && thrustTerminal.sprite != DeActiveThruster)
            thrustTerminal.sprite = DeActiveThruster;
    }
}
