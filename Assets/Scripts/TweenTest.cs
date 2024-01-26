using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Muks.Tween;

public class TweenTest : MonoBehaviour
{
    [SerializeField] private TweenMode _tweenMode;
    [SerializeField] private LoopType _loopType;
    void Start()
    {
        Tween.TransformMove(gameObject, new Vector3(0, -3, 0), 1, _tweenMode).Loop(_loopType);
    }

}
