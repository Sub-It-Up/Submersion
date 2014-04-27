using UnityEngine;
using System.Collections;

public class MissileTerminalBehavior : MonoBehaviour
{
    public PlayerBehavior PlayerObject;
    public Transform[] MissileFirePoints;
    public GameObject[] MissileObjects;
    public float FireDelayTime = .5f;
    public float DistanceFrom = .5f;

    private float elapsedTimeSinceFire = -1;

    // Update is called once per frame
    void Update()
    {
        if (elapsedTimeSinceFire < 0 && Vector2.SqrMagnitude(PlayerObject.transform.position - this.transform.position) < DistanceFrom
            && Input.GetKeyDown(KeyCode.E))
        {
            int randomFirePointIndex = Random.Range(0, MissileFirePoints.Length);
            int randomMissile = Random.Range(0, MissileObjects.Length);
            Vector2 randomFirePoint = MissileFirePoints[randomFirePointIndex].position;

            GameObject.Instantiate(MissileObjects[randomMissile], randomFirePoint, Quaternion.identity);

            elapsedTimeSinceFire = FireDelayTime;
        }
        else if (elapsedTimeSinceFire > 0)
            elapsedTimeSinceFire -= Time.deltaTime;
    }
}
