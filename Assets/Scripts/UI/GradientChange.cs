using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GradientChange : MonoBehaviour
{
    public Color colorIni = Color.white;
    public Color colorFin = Color.black;
    public float duration = 3f;
    Color lerpedColor = Color.white;
    public bool isImage;
    public bool toggle;

    [HideInInspector] public float t = 0;
    [HideInInspector] public bool flag;

    SpriteRenderer _renderer;
    Image _image;

    private void OnEnable()
    {
        t = 0;
        flag = true;
        toggle = false;
    }

    private void OnDisable()
    {
        toggle = true;
    }

    // Use this for initialization
    void Start()
    {
        if(!isImage)
            _renderer = GetComponent<SpriteRenderer>();

        if (isImage)
            _image = GetComponent<Image>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        if (!isImage)
        {
            _renderer.color = lerpedColor;
        }

        if(isImage)
        {
            _image.color = lerpedColor;
        }
        //Fade back in
        if (flag == true)
        {
            if (!isImage)
            {
                t -= Time.deltaTime / duration;
                if (t <= 0.01f)
                    flag = false;
            }
        }

        //Fade in
        else
        {
             t += Time.deltaTime / duration;
             if (t >= 0.99f)
                 flag = true;
        }
    }

    public void Refresh()
    {
        t = 0;
        flag = true;
    }
}