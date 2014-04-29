using UnityEngine;
using System.Collections;

public class TitleScreenBehavior : MonoBehaviour
{
    public SpriteRenderer BackgroundFade;

    private bool activeTransition = false;

    public bool ActiveTransition
    {
        get { return activeTransition; }
        set { activeTransition = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ActiveTransition)
        {
            if (BackgroundFade.color.a > 0)
            {
                BackgroundFade.color = new Color(BackgroundFade.color.r,
                    BackgroundFade.color.g, BackgroundFade.color.b, BackgroundFade.color.a - .25f * Time.deltaTime);

                if (BackgroundFade.color.a < 0)
                    BackgroundFade.color = new Color(BackgroundFade.color.r,
                    BackgroundFade.color.g, BackgroundFade.color.b, 0);
            }

            if (audio.volume < .25f)
                audio.volume += .25f * Time.deltaTime;
        }
        else
        {
            if (BackgroundFade.color.a < 1)
            {
                BackgroundFade.color = new Color(BackgroundFade.color.r,
                    BackgroundFade.color.g, BackgroundFade.color.b, BackgroundFade.color.a + Time.deltaTime);

                if (BackgroundFade.color.a > 1)
                    Application.LoadLevel(1); // Load Main Game
            }
        }
    }
}
