using UnityEngine;
using System.Collections;

public class WaterFountainBehavior : MonoBehaviour
{
    public float DistanceFromToFix = .15f;

    private PlayerBehavior[] PlayerObject = new PlayerBehavior[2];
    private bool toBeDestroyed = false;

    // Use this for initialization
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "PlayerLayer";
        particleSystem.renderer.sortingOrder = 2;

        PlayerObject = (PlayerBehavior[])PlayerBehavior.FindObjectsOfType(typeof(PlayerBehavior));
    }

    // Update is called once per frame
    void Update()
    {
        if (!toBeDestroyed && !GameObject.Find("MainPlayerShip").GetComponent<PlayerShipBehavior>().Dead())
        {
            Camera.main.GetComponent<CameraBehavior>().CurrentHealth -= .15f * Time.deltaTime;
        }

        for (int i = 0; i < PlayerObject.Length; i++)
        {
            float DistanceAway = (PlayerObject[i].transform.position - this.transform.position).sqrMagnitude;

            if (DistanceAway < DistanceFromToFix && Input.GetAxis("RightButton" + PlayerObject[i].playerNum) > 0)
            {
                this.particleSystem.loop = false;
                GameObject.Destroy(this.transform.parent.gameObject, 1.75f);
                toBeDestroyed = true;
            }
        }
    }

    void OnDestroy()
    {
        GameObject.Find("MainPlayerShip").GetComponent<PlayerShipBehavior>().LeakCount--;
    }
}
