using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sizing : MonoBehaviour
{
    // данным скриптом устанавливаем размеры и масштаб кубов
    
    private int width ;
    private int height ;
    public static float scale;
    public void Sized()
    {
        width = FieldCreation.width;
        height = FieldCreation.height;

        if(width >= height)
        {
            scale = 8f / width;
        }
        else if (width < height)
        {
            scale = 8f / height;
        }
       
        Debug.Log(height);
        Debug.Log(scale);
        gameObject.transform.localScale = new Vector3(scale, scale, 0);
    }
}
