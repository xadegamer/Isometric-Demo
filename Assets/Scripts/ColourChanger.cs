using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public Color[] colour;

    public void ChangeColour(int index)
    {
        gameObject.ChangeColour(colour[index]);
    }
}
