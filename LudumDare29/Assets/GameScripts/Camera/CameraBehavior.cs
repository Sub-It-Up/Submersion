using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{
    public float WrapMaxSize = 5;               // The max value for when to wrap
    public PlayerShipBehavior PlayerShipObject; // The player ship object to keep track of

    // wrap only the Player Ship Object right now
    // going to have to make it so the player(s) inside also wrap
    private void DetermineScreenWrap()
    {
        if (PlayerShipObject.transform.position.y - PlayerShipObject.getColliderExtents().y < -WrapMaxSize)
            PlayerShipObject.transform.position = new Vector2(PlayerShipObject.transform.position.x, WrapMaxSize - PlayerShipObject.getColliderExtents().y);
        else if (PlayerShipObject.transform.position.y + PlayerShipObject.getColliderExtents().y > WrapMaxSize)
            PlayerShipObject.transform.position = new Vector2(PlayerShipObject.transform.position.x, -WrapMaxSize + PlayerShipObject.getColliderExtents().y);
        else if (PlayerShipObject.transform.position.x - PlayerShipObject.getColliderExtents().x < -2 * WrapMaxSize)
            PlayerShipObject.transform.position = new Vector2(2 * WrapMaxSize - PlayerShipObject.getColliderExtents().x, PlayerShipObject.transform.position.y);
        else if (PlayerShipObject.transform.position.x + PlayerShipObject.getColliderExtents().x > 2 * WrapMaxSize)
            PlayerShipObject.transform.position = new Vector2(-2 * WrapMaxSize + PlayerShipObject.getColliderExtents().x, PlayerShipObject.transform.position.y);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetermineScreenWrap();
    }
}
