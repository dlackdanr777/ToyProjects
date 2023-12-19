using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

///<summary> ����ð��� ���� �ӵ��� ��� �޸� ���� ���ΰ�? </summary>
public enum TweenMode
{
    /// <summary>���</summary>
    Constant,

    /// <summary>����</summary>
    Quadratic,

    /// <summary>õõ�� ���� õõ�� ����</summary>
    Smoothstep,

    /// <summary>���� õõ�� ���� ���� õõ�� ����</summary>
    Smootherstep,

    /// <summary>������ ��ġ�� ���ٰ� ���ڸ��� ���ư�</summary>
    Spike,

    /// <summary>������ ��ġ�� ���� ������ ƨ��</summary>
    EaseInOutElastic,

    /// <summary>�������ϰ� ��ġ�� ���� �ѹ� ƨ��</summary>
    EaseInOutBack,

    /// <summary>Sin �׷��� �̵�</summary>
    Sinerp,

    /// <summary>Cos �׷��� �̵�</summary>
    Coserp,
}

/// <summary>
/// Ʈ�� �ִϸ��̼��� ���� ���� Ŭ����
/// </summary>

namespace Muks.Tween
{
    public static class Tween
    {

        public static void Stop(GameObject gameObject)
        {
            TweenData[] tweens = gameObject.GetComponents<TweenData>();

            foreach(TweenData tween in tweens)
            {
                tween.enabled = false;
            }

        }





        /// <summary>
        /// ���ӽð���ŭ ������Ʈ�� �̵���Ű�� �Լ�
        /// </summary>
        /// 
        public static void TransformMove(GameObject targetObject, Vector3 targetPosition, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformMove objToMove = !targetObject.GetComponent<TweenTransformMove>()
                ? targetObject.AddComponent<TweenTransformMove>()
                : targetObject.GetComponent<TweenTransformMove>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetPosition;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToMove.AddDataSequence(tempData);

            if (!objToMove.enabled)
            {
                objToMove.ElapsedDuration = 0;
                objToMove.TotalDuration = 0;
                objToMove.enabled = true;
            }
        }


        public static void TransformMove(GameObject targetObject, Vector3 targetPosition, float duration, int repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformMove objToMove = !targetObject.GetComponent<TweenTransformMove>()
                ? targetObject.AddComponent<TweenTransformMove>()
                : targetObject.GetComponent<TweenTransformMove>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetPosition;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToMove.AddDataSequence(tempData);
            }

            if (!objToMove.enabled)
            {
                objToMove.ElapsedDuration = 0;
                objToMove.TotalDuration = 0;
                objToMove.enabled = true;
            }
        }


        public static void TransformRotate(GameObject targetObject, Vector3 targetEulerAngles, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformRotate objToRotate = !targetObject.GetComponent<TweenTransformRotate>()
                ? targetObject.AddComponent<TweenTransformRotate>()
                : targetObject.GetComponent<TweenTransformRotate>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetEulerAngles;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToRotate.AddDataSequence(tempData);

            if (!objToRotate.enabled)
            {
                objToRotate.ElapsedDuration = 0;
                objToRotate.TotalDuration = 0;
                objToRotate.enabled = true;
            }
        }


        public static void TransformRotate(GameObject targetObject, Vector3 targetEulerAngles, float duration, int repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformRotate objToRotate = !targetObject.GetComponent<TweenTransformRotate>()
                ? targetObject.AddComponent<TweenTransformRotate>()
                : targetObject.GetComponent<TweenTransformRotate>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetEulerAngles;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToRotate.AddDataSequence(tempData);
            }

            if (!objToRotate.enabled)
            {
                objToRotate.ElapsedDuration = 0;
                objToRotate.TotalDuration = 0;
                objToRotate.enabled = true;
            }
        }


        public static void TransformScale(GameObject targetObject, Vector3 targetScale, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformScale objToScale = !targetObject.GetComponent<TweenTransformScale>()
                ? targetObject.AddComponent<TweenTransformScale>()
                : targetObject.GetComponent<TweenTransformScale>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetScale;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToScale.AddDataSequence(tempData);

            if (!objToScale.enabled)
            {
                objToScale.ElapsedDuration = 0;
                objToScale.TotalDuration = 0;
                objToScale.enabled = true;
            }
        }


        public static void TransformScale(GameObject targetObject, Vector3 targetScale, float duration, int repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTransformScale objToScale = !targetObject.GetComponent<TweenTransformScale>()
                ? targetObject.AddComponent<TweenTransformScale>()
                : targetObject.GetComponent<TweenTransformScale>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetScale;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToScale.AddDataSequence(tempData);
            }

            if (!objToScale.enabled)
            {
                objToScale.ElapsedDuration = 0;
                objToScale.TotalDuration = 0;
                objToScale.enabled = true;
            }
        }


        public static void RectTransfromSizeDelta(GameObject targetObject, Vector2 targetSizeDelta, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenRectTransformSizeDelta objToSizeDelta = !targetObject.GetComponent<TweenRectTransformSizeDelta>()
                ? targetObject.AddComponent<TweenRectTransformSizeDelta>()
                : targetObject.GetComponent<TweenRectTransformSizeDelta>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetSizeDelta;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToSizeDelta.AddDataSequence(tempData);

            if (!objToSizeDelta.enabled)
            {
                objToSizeDelta.ElapsedDuration = 0;
                objToSizeDelta.TotalDuration = 0;
                objToSizeDelta.enabled = true;
            }
        }

        public static void RectTransfromSizeDelta(GameObject targetObject, Vector2 targetSizeDelta, float duration, int repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenRectTransformSizeDelta objToSizeDelta = !targetObject.GetComponent<TweenRectTransformSizeDelta>()
                ? targetObject.AddComponent<TweenRectTransformSizeDelta>()
                : targetObject.GetComponent<TweenRectTransformSizeDelta>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetSizeDelta;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToSizeDelta.AddDataSequence(tempData);
            }

            if (!objToSizeDelta.enabled)
            {
                objToSizeDelta.ElapsedDuration = 0;
                objToSizeDelta.TotalDuration = 0;
                objToSizeDelta.enabled = true;
            }
        }

        public static void RectTransfromAnchoredPosition(GameObject targetObject, Vector2 targetAnchoredPosition, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenRectTransformAnchoredPosition objToAnchoredPosition = !targetObject.GetComponent<TweenRectTransformAnchoredPosition>()
                ? targetObject.AddComponent<TweenRectTransformAnchoredPosition>()
                : targetObject.GetComponent<TweenRectTransformAnchoredPosition>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetAnchoredPosition;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToAnchoredPosition.AddDataSequence(tempData);

            if (!objToAnchoredPosition.enabled)
            {
                objToAnchoredPosition.ElapsedDuration = 0;
                objToAnchoredPosition.TotalDuration = 0;
                objToAnchoredPosition.enabled = true;
            }
        }

        public static void RectTransfromAnchoredPosition(GameObject targetObject, Vector2 targetAnchoredPosition, float duration, int repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenRectTransformAnchoredPosition objToAnchoredPosition = !targetObject.GetComponent<TweenRectTransformAnchoredPosition>()
                ? targetObject.AddComponent<TweenRectTransformAnchoredPosition>()
                : targetObject.GetComponent<TweenRectTransformAnchoredPosition>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetAnchoredPosition;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToAnchoredPosition.AddDataSequence(tempData);
            }

            if (!objToAnchoredPosition.enabled)
            {
                objToAnchoredPosition.ElapsedDuration = 0;
                objToAnchoredPosition.TotalDuration = 0;
                objToAnchoredPosition.enabled = true;
            }
        }


        public static void IamgeColor(GameObject targetObject, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenImageColor objToColor = !targetObject.GetComponent<TweenImageColor>()
                ? targetObject.AddComponent<TweenImageColor>()
                : targetObject.GetComponent<TweenImageColor>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetColor;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void IamgeColor(GameObject targetObject, Color targetColor, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenImageColor objToColor = !targetObject.GetComponent<TweenImageColor>()
                ? targetObject.AddComponent<TweenImageColor>()
                : targetObject.GetComponent<TweenImageColor>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetColor;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void IamgeAlpha(GameObject targetObject, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenImageAlpha objToColor = !targetObject.GetComponent<TweenImageAlpha>()
                ? targetObject.AddComponent<TweenImageAlpha>()
                : targetObject.GetComponent<TweenImageAlpha>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetAlpha;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }

        public static void IamgeAlpha(GameObject targetObject, float targetAlpha, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenImageAlpha objToColor = !targetObject.GetComponent<TweenImageAlpha>()
                ? targetObject.AddComponent<TweenImageAlpha>()
                : targetObject.GetComponent<TweenImageAlpha>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetAlpha;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TextColor(GameObject targetObject, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTextColor objToColor = !targetObject.GetComponent<TweenTextColor>()
                ? targetObject.AddComponent<TweenTextColor>()
                : targetObject.GetComponent<TweenTextColor>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetColor;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }

        public static void TextColor(GameObject targetObject, Color targetColor, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTextColor objToColor = !targetObject.GetComponent<TweenTextColor>()
                ? targetObject.AddComponent<TweenTextColor>()
                : targetObject.GetComponent<TweenTextColor>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetColor;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TextAlpha(GameObject targetObject, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTextAlpha objToColor = !targetObject.GetComponent<TweenTextAlpha>()
                ? targetObject.AddComponent<TweenTextAlpha>()
                : targetObject.GetComponent<TweenTextAlpha>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetAlpha;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }

        public static void TextAlpha(GameObject targetObject, float targetAlpha, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTextAlpha objToColor = !targetObject.GetComponent<TweenTextAlpha>()
                ? targetObject.AddComponent<TweenTextAlpha>()
                : targetObject.GetComponent<TweenTextAlpha>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetAlpha;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                tempData.OnComplete = onComplete;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TMPColor(GameObject targetObject, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTMPColor objToColor = !targetObject.GetComponent<TweenTMPColor>()
                ? targetObject.AddComponent<TweenTMPColor>()
                : targetObject.GetComponent<TweenTMPColor>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetColor;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TMPColor(GameObject targetObject, Color targetColor, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTMPColor objToColor = !targetObject.GetComponent<TweenTMPColor>()
                ? targetObject.AddComponent<TweenTMPColor>()
                : targetObject.GetComponent<TweenTMPColor>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetColor;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TMPAlpha(GameObject targetObject, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTMPAlpha objToColor = !targetObject.GetComponent<TweenTMPAlpha>()
                ? targetObject.AddComponent<TweenTMPAlpha>()
                : targetObject.GetComponent<TweenTMPAlpha>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetAlpha;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void TMPAlpha(GameObject targetObject, float targetAlpha, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenTMPAlpha objToColor = !targetObject.GetComponent<TweenTMPAlpha>()
                ? targetObject.AddComponent<TweenTMPAlpha>()
                : targetObject.GetComponent<TweenTMPAlpha>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetAlpha;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                tempData.OnComplete = onComplete;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void SpriteRendererColor(GameObject targetObject, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenSpriteRendererColor objToColor = !targetObject.GetComponent<TweenSpriteRendererColor>()
                ? targetObject.AddComponent<TweenSpriteRendererColor>()
                : targetObject.GetComponent<TweenSpriteRendererColor>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetColor;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void SpriteRendererColor(GameObject targetObject, Color targetColor, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenSpriteRendererColor objToColor = !targetObject.GetComponent<TweenSpriteRendererColor>()
                ? targetObject.AddComponent<TweenSpriteRendererColor>()
                : targetObject.GetComponent<TweenSpriteRendererColor>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetColor;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }


        public static void SpriteRendererAlpha(GameObject targetObject, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenSpriteRendererAlpha objToColor = !targetObject.GetComponent<TweenSpriteRendererAlpha>()
                ? targetObject.AddComponent<TweenSpriteRendererAlpha>()
                : targetObject.GetComponent<TweenSpriteRendererAlpha>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetAlpha;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            objToColor.AddDataSequence(tempData);

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }

        public static void SpriteRendererAlpha(GameObject targetObject, float targetAlpha, float duration, float repeatCount, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null)
        {
            TweenSpriteRendererAlpha objToColor = !targetObject.GetComponent<TweenSpriteRendererAlpha>()
                ? targetObject.AddComponent<TweenSpriteRendererAlpha>()
                : targetObject.GetComponent<TweenSpriteRendererAlpha>();

            for (int i = 0; i < repeatCount; i++)
            {
                DataSequence tempData = new DataSequence();
                tempData.TargetValue = targetAlpha;
                tempData.Duration = duration;
                tempData.TweenMode = tweenMode;
                if (onComplete != null && i == repeatCount - 1)
                    tempData.OnComplete = onComplete;

                objToColor.AddDataSequence(tempData);
            }

            if (!objToColor.enabled)
            {
                objToColor.ElapsedDuration = 0;
                objToColor.TotalDuration = 0;
                objToColor.enabled = true;
            }
        }
    }
}

