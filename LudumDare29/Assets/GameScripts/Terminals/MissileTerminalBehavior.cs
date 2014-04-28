using UnityEngine;
using System.Collections;

public class MissileTerminalBehavior : MonoBehaviour
{
    public PlayerBehavior[] PlayerObject = new PlayerBehavior[2];
    public Transform[] MissileFirePoints;
    public GameObject[] MissileObjects;
    public float FireDelayTime = .5f;
    public float DistanceFrom = .5f;

    public Sprite DeActiveTerminal;
    public Sprite NearTerminal;
    public Sprite ActivatedTerminal;

    private float elapsedTimeSinceFire = -1, elapsedTimeActivated = 0;
    private SpriteRenderer missileTerminal;

    void Start()
    {
        missileTerminal = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int nearTerminalCount = 0;

        for (int i = 0; i < 2; ++i)
        {
            if (Vector2.SqrMagnitude(PlayerObject[i].transform.position - this.transform.position) < DistanceFrom)
            {
                if (elapsedTimeActivated < 0 && missileTerminal.sprite != NearTerminal)
                    missileTerminal.sprite = NearTerminal;
                else
                    elapsedTimeActivated -= Time.deltaTime;

                if (elapsedTimeSinceFire < 0 && (Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0 || Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0))
                {
                    int randomFirePointIndex = Random.Range(0, MissileFirePoints.Length);
                    int randomMissile = Random.Range(0, MissileObjects.Length);
                    Vector2 randomFirePoint = MissileFirePoints[randomFirePointIndex].position;

                    GameObject newMissile = (GameObject)GameObject.Instantiate(MissileObjects[randomMissile], randomFirePoint, Quaternion.identity);

                    newMissile.transform.rotation = Quaternion.AngleAxis(transform.parent.rotation.eulerAngles.z, Vector3.forward);

                    elapsedTimeSinceFire = FireDelayTime;
                    elapsedTimeActivated = FireDelayTime / 2;

                    missileTerminal.sprite = ActivatedTerminal;
                }
                else if (elapsedTimeSinceFire > 0)
                    elapsedTimeSinceFire -= Time.deltaTime;

                nearTerminalCount++;
            }
        }

        if (nearTerminalCount == 0 && missileTerminal.sprite != DeActiveTerminal)
            missileTerminal.sprite = DeActiveTerminal;
    }
}
