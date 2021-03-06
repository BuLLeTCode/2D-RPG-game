﻿using UnityEngine;
using System.Collections;

public class SceneTransformation : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed = 0.8f;

    private int drawDeepth = -1000;
    private float alpha = 1f;
    private int fadeDir = -1; //-1 for FadeIn and 1 for FadeOut

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDeepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);   
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
