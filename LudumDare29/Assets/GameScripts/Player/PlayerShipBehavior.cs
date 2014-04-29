using UnityEngine;
using System.Collections;

public class PlayerShipBehavior : MonoBehaviour
{
    public AudioClip ChainExplosion;

    private Vector2 colliderExtents;
    private int leakCount = 0;
    private bool isDead = false;

    private CameraBehavior mainCamera;

    public int LeakCount
    {
        get { return leakCount; }
        set { leakCount = value; }
    }

    public bool Dead()
    {
        return isDead;
    }

    // Use this for initialization
    void Start()
    {
        // BoxCollider2D hack for obtaining size of object
        colliderExtents = GetComponent<BoxCollider2D>().size * .5f;
        mainCamera = Camera.main.GetComponent<CameraBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && leakCount == 0 && mainCamera.CurrentHealth < mainCamera.GetMaxHealth())
        {
            mainCamera.CurrentHealth += .095f * Time.deltaTime;

            Debug.Log(mainCamera.CurrentHealth);

            if (mainCamera.CurrentHealth > mainCamera.GetMaxHealth())
                mainCamera.CurrentHealth = mainCamera.GetMaxHealth();
        }
        else if (mainCamera.CurrentHealth <= 0 && !isDead)
        {
            isDead = true;
            GameObject.Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(ChainExplosion, transform.position, 1);
        }
    }

    public Vector2 getColliderExtents()
    {
        return colliderExtents;
    }
}
