/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk membuat animasi fadein/fadeout
 **************************************************************************************************************/
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class FadeController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [System.Serializable]
        public class CFadeSettings {
            public Color SplashColor;
            public float StartDelay;
            public float AlphaSpeed;

            [HideInInspector] public float _alpha = 1;
            [HideInInspector] public Texture2D _texture;
            [HideInInspector] public bool _done;
            [HideInInspector] public float _time;
            [HideInInspector] public bool _isfading = false;
        }

        [Header("FadeIn Settings")]
        public bool usingFadeIn;
        public CFadeSettings FadeInSettings;

        [Header("FadeOut Settings")]
        public bool usingFadeOut;
        public CFadeSettings FadeOutSettings;

        public void Awake()
        {
            if (isEnabled)
            {
                if (usingFadeIn)
                {
                    if (FadeInSettings.StartDelay > 0)
                    {
                        FadeInSettings._alpha = 1;
                        Invoke("ExecFadeIn", FadeInSettings.StartDelay);
                    }
                    else
                    {
                        FadeInSettings._isfading = true;
                    }
                }
                if (usingFadeOut)
                {
                    if (FadeOutSettings.StartDelay > 0)
                    {
                        FadeOutSettings._alpha = 0;
                        Invoke("ExecFadeOut", FadeOutSettings.StartDelay);
                    }
                    else
                    {
                        FadeOutSettings._alpha = 0;
                        FadeOutSettings._isfading = true;
                    }
                }

            }
        }

        void ExecFadeIn()
        {
            FadeInSettings._isfading = true;
        }

        void ExecFadeOut()
        {
            FadeOutSettings._isfading = true;
        }

        public void Reset()
        {
            if (usingFadeIn)
            {
                FadeInSettings._done = false;
                FadeInSettings._time = 0;
                FadeInSettings._alpha = 1;
            }
            if (usingFadeOut)
            {
                FadeOutSettings._done = false;
                FadeOutSettings._time = 0;
                FadeOutSettings._alpha = 0;
            }
        }

        [RuntimeInitializeOnLoadMethod]
        public void RedoFade()
        {
            Reset();
        }

        public void OnGUI()
        {
            if (isEnabled && FadeInSettings._isfading && usingFadeIn)
            {
                if (FadeInSettings._done) return;
                if (FadeInSettings._texture == null) FadeInSettings._texture = new Texture2D(1, 1);

                FadeInSettings._texture.SetPixel(0, 0, new Color(FadeInSettings.SplashColor.r, FadeInSettings.SplashColor.g, FadeInSettings.SplashColor.b, FadeInSettings._alpha));
                FadeInSettings._texture.Apply();

                FadeInSettings._time += Time.deltaTime * FadeInSettings.AlphaSpeed;

                if (usingFadeIn)
                {
                    FadeInSettings._alpha -= FadeInSettings._time * Time.deltaTime;
                }

                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeInSettings._texture);

                if (FadeInSettings._alpha <= 0) FadeInSettings._done = true;
            }
            if (isEnabled && FadeOutSettings._isfading && usingFadeOut)
            {
                if (FadeOutSettings._texture == null) FadeOutSettings._texture = new Texture2D(1, 1);
                FadeOutSettings._texture.SetPixel(0, 0, new Color(FadeOutSettings.SplashColor.r, FadeOutSettings.SplashColor.g, FadeOutSettings.SplashColor.b, FadeOutSettings._alpha));
                FadeOutSettings._texture.Apply();

                if (!FadeOutSettings._done)
                {
                    FadeOutSettings._time += Time.deltaTime * FadeOutSettings.AlphaSpeed;
                    if (usingFadeOut)
                    {
                        FadeOutSettings._alpha += FadeOutSettings._time * Time.deltaTime;
                    }
                }

                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutSettings._texture);

                if (FadeOutSettings._alpha > 1) FadeOutSettings._done = true;
            }

        }
    }
}