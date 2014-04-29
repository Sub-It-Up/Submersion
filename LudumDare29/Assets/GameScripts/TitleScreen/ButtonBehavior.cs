using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour
{
    public Sprite InActive;
    public Sprite Active;

    private SpriteRenderer buttonSprite;
    private bool activeHover = false;

    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        if (buttonSprite.sprite != Active)
        {
            buttonSprite.sprite = Active;
            activeHover = true;
        }
    }

    void OnMouseExit()
    {
        if (buttonSprite.sprite != InActive)
        {
            buttonSprite.sprite = InActive;
            activeHover = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && activeHover)
        {
            if (this.transform.name == "NewGame")
                Camera.main.GetComponent<TitleScreenBehavior>().ActiveTransition = true;
            else if (this.transform.name == "ExitGame")
                Application.Quit();
        }
    }
}
