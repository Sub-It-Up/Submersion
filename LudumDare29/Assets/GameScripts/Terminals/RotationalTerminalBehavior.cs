using UnityEngine;
using System.Collections;

public class RotationalTerminalBehavior : MonoBehaviour
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior[] PlayerObject;
    public float DistanceFrom = .5f;
    public float RotationStrength = 1;

    public Sprite NuetralLever;
    public Sprite LeftLever;
    public Sprite RightLever;

    private SpriteRenderer rotationalTerminal;

    void Start()
    {
        rotationalTerminal = GetComponent<SpriteRenderer>();
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
                    if (rotationalTerminal.sprite != RightLever)
                        rotationalTerminal.sprite = RightLever;

                    PlayerShipPhysics.dirDeg -= RotationStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
                else if (Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0)
                {
                    if (rotationalTerminal.sprite != LeftLever)
                        rotationalTerminal.sprite = LeftLever;

                    PlayerShipPhysics.dirDeg += RotationStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
            }
        }

        if (activeButtons[0] == false && activeButtons[1] == false && rotationalTerminal.sprite != NuetralLever)
            rotationalTerminal.sprite = NuetralLever;
    }
}
