using UnityEngine;
using System.Collections;

public class BalistTerminalBehavior : MonoBehaviour
{
    public ShipPhysics PlayerShipPhysics;
    public PlayerBehavior[] PlayerObject;
    public float DistanceFrom = .5f;
    public float BalistStrength = 1;

    public Sprite DeActiveBalist;
    public Sprite NearBalist;

    private SpriteRenderer balistTerminal;
    private Animator balistAnimator;

    void Start()
    {
        balistTerminal = GetComponent<SpriteRenderer>();
        balistAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool[] activeButtons = { false, false };

        for (int i = 0; i < 2; ++i)
        {
            if (Vector2.SqrMagnitude(PlayerObject[i].transform.position - this.transform.position) < DistanceFrom)
            {
                if (balistTerminal.sprite != NearBalist && !balistAnimator.enabled)
                    balistTerminal.sprite = NearBalist;

                if (Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0)
                {
                    if (!balistAnimator.enabled)
                        balistAnimator.enabled = true;

                    PlayerShipPhysics.balist += BalistStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
                else if (Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0)
                {
                    if (!balistAnimator.enabled)
                        balistAnimator.enabled = true;

                    PlayerShipPhysics.balist -= BalistStrength * Time.deltaTime;

                    activeButtons[i] = true;
                }
            }
        }

        if (activeButtons[0] == false && activeButtons[1] == false && balistTerminal.sprite != DeActiveBalist)
        {
            balistAnimator.enabled = false; // disable just in case
            balistTerminal.sprite = DeActiveBalist;
        }
    }
}
