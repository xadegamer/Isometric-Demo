using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    private static Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    public static Vector3 ToIsometric(this Vector3 input) => matrix.MultiplyPoint3x4(input);
}
