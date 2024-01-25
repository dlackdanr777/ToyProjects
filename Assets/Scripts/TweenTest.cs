using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Muks.Tween;

public class TweenTest : MonoBehaviour
{
    [SerializeField] private TweenMode _tweenMode;
    void Start()
    {
        Tween.TransformMove(gameObject, new Vector3(0, -3, 0), 1, _tweenMode);
    }

}
