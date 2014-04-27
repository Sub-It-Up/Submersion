using UnityEngine;
using System.Collections;

public class MissileTerminalBehavior : MonoBehaviour
{
    public PlayerBehavior[] PlayerObject = new PlayerBehavior[2];
    public Transform[] MissileFirePoints;
    public GameObject[] MissileObjects;
    public float FireDelayTime = .5f;
    public float DistanceFrom = .5f;

    private float elapsedTimeSinceFire = -1;

    // Update is called once per frame
    void Update()
    {
    for (int i = 0; i < 2; ++i)
    {
      if (elapsedTimeSinceFire < 0 && Vector2.SqrMagnitude(PlayerObject[i].transform.position - this.transform.position) < DistanceFrom
      && (Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0 || Input.GetAxis("LeftButton" + PlayerObject[i].playerNum) > 0))
      {
          int randomFirePointIndex = Random.Range(0, MissileFirePoints.Length);
          int randomMissile = Random.Range(0, MissileObjects.Length);
          Vector2 randomFirePoint = MissileFirePoints[randomFirePointIndex].position;

          GameObject newMissile = (GameObject)GameObject.Instantiate(MissileObjects[randomMissile], randomFirePoint, Quaternion.identity);

          newMissile.transform.rotation = Quaternion.AngleAxis(transform.parent.rotation.eulerAngles.z, Vector3.forward);

          elapsedTimeSinceFire = FireDelayTime;
      }
      else if (elapsedTimeSinceFire > 0)
         elapsedTimeSinceFire -= Time.deltaTime;
    }
    }
}
