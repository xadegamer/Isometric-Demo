using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feel : MonoBehaviour
{
    [SerializeField] private RotateStat rotateStat;
    [SerializeField] private List<FeelMoveProperties> moveProperties;
    [SerializeField] private List<FeelScaleProperties> scaleProperties;
    [SerializeField] private List<FeelColorProperties> colorProperties;
    [SerializeField] private List<FeelRotateProperties> rotateProperties;


    void Start()
    {
       /// StartCoroutine(LoopRotateObject(rotateStat, transform));

        StartCoroutine(LoopMoveWithProperies(transform, moveProperties, true));

        StartCoroutine(ScaleObject(transform, scaleProperties, true));

        StartCoroutine(ChangeFadeColor(GetComponent<Renderer>(), colorProperties, true));

        StartCoroutine(RotateObject(transform , rotateProperties, true));
    }

    IEnumerator LoopMoveWithProperies(Transform thisTransform, List<FeelMoveProperties> moveProperties, bool loop, int index = 0)
    {
        float i = 0.0f;
        float rate = 1.0f / moveProperties[index].duration;
        Vector3 startPos = thisTransform.position;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, moveProperties[index].position, moveProperties[index].animationCurve.Evaluate(i));
            yield return null;
        }

        if(loop)
        {
            index = (index + 1) % moveProperties.Count;
            yield return LoopMoveWithProperies(thisTransform, moveProperties, loop, index);
        }
    }

    IEnumerator ScaleObject(Transform thisTransform, List<FeelScaleProperties> endScales, bool loop, int index = 0)
    {
        float i = 0.0f;
        float rate = 1.0f / endScales[index].duration;
        Vector3 startScale = thisTransform.localScale;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.localScale = Vector3.Lerp(startScale, endScales[index].scale, endScales[index].animationCurve.Evaluate(i));
            yield return null;
        }

        if (loop)
        {
            index = (index + 1) % endScales.Count;
            yield return ScaleObject(thisTransform, endScales, loop, index);
        }
    }

    IEnumerator ChangeFadeColor(Renderer renderer, List<FeelColorProperties> colorProperties, bool loop, int index = 0)
    {
        float i = 0.0f;
        float rate = 1.0f / colorProperties[index].duration;
        Color startColor = renderer.material.color;
        Color endColor = colorProperties[index].color;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            renderer.material.color = Color.Lerp(startColor, endColor, colorProperties[index].animationCurve.Evaluate(i));
            yield return null;
        }

        if (loop)
        {
            index = (index + 1) % colorProperties.Count;
            yield return ChangeFadeColor(renderer, colorProperties, loop, index);
        }
    }

    IEnumerator RotateObject(Transform thisTransform, List<FeelRotateProperties>  rotateProperties, bool loop, int index = 0)
    {
        float i = 0.0f;
        float rate = 1.0f / rotateProperties[index].duration;
        Vector3 startRotation = thisTransform.eulerAngles;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.eulerAngles = Vector3.Lerp(startRotation, rotateProperties[index].rotation, rotateProperties[index].animationCurve.Evaluate(i));
            yield return null;
        }

        if (loop)
        {
            index = (index + 1) % rotateProperties.Count;
            yield return RotateObject(thisTransform, rotateProperties, loop, index);
        }
    }

    IEnumerator LoopRotateObject(RotateStat rotateStat, Transform thisTransform)
    {
        while (true)
        {
            if(rotateStat.canRotate) thisTransform.Rotate(0, 0, 1);
            yield return null;
        }
    }
}

    [Serializable]
    public class RotateStat
    {
        public bool canRotate;
    }

    [Serializable]
    public class FeelMoveProperties
    {
        public Vector3 position;
        public float duration;
        public AnimationCurve animationCurve;
    }

    [Serializable]
    public class FeelScaleProperties
    {
        public Vector3 scale;
        public float duration;
        public AnimationCurve animationCurve;
    }

    [Serializable]
    public class FeelColorProperties
    {
        public Color color;
        public float duration;
        public AnimationCurve animationCurve;
    }

    [Serializable]
    public class FeelRotateProperties
    {
        public Vector3 rotation;
        public float duration;
        public AnimationCurve animationCurve;
    }