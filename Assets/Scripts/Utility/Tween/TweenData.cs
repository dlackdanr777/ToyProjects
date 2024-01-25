using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Muks.Tween
{
    public struct DataSequence
    {
        public object StartValue;
        public object TargetValue;
        public float Duration;
        public TweenMode TweenMode;
        public Action OnComplete;
    }

    public class TweenData : MonoBehaviour
    {
        public Queue<DataSequence> DataSequences = new Queue<DataSequence>();

        ///  <summary> ���� ��� �ð� </summary>
        public float ElapsedDuration;

        ///  <summary> �� ��� �ð� </summary>
        public float TotalDuration;

        ///  <summary> �ݹ� �Լ� </summary>
        public Action OnComplete;

        public TweenMode TweenMode;

        public bool IsLoop;

        protected Dictionary<TweenMode, Func<float, float, float>> _percentHandler;

        private bool _isRightMove = true;

        public virtual void SetData(DataSequence dataSequence)
        {
            TotalDuration = dataSequence.Duration;
            TweenMode = dataSequence.TweenMode;
            OnComplete = dataSequence.OnComplete;
        }


        //���� �ݺ�
        public void Loop()
        {
            DataSequence sequence = DataSequences.Last();
            DataSequences.Clear();
            DataSequences.Enqueue(sequence);
            SetData(DataSequences.Dequeue());
            IsLoop = true;
        }

        //�ݺ� Ƚ�� ����
        public void Repeat(int count)
        {
            DataSequence sequence = DataSequences.Last();

            for (int i = 1; i < count; i++)
            {
                AddDataSequence(sequence);
            }
        }


        private void Awake()
        {
            _percentHandler = new Dictionary<TweenMode, Func<float, float, float>>
            {
                { TweenMode.Constant, Constant },
                {TweenMode.Quadratic, Quadratic },
                { TweenMode.Smoothstep, Smoothstep },
                { TweenMode.Smootherstep, Smootherstep },
                {TweenMode.Spike, Spike },
                {TweenMode.EaseInOutElastic, EaseInOutElastic },
                {TweenMode.EaseInOutBack, EaseInOutBack },
                { TweenMode.Sinerp, Sinerp },
                { TweenMode.Coserp, Coserp }
            };
        }


        protected virtual void Update()
        {
            //���� �ݺ� ������ �Ǿ��ִٸ�?
            if (IsLoop)
            {
                ElapsedDuration += _isRightMove ? Time.deltaTime : -Time.deltaTime;
                ElapsedDuration = Mathf.Clamp(ElapsedDuration, 0, TotalDuration);

                if (_isRightMove && TotalDuration <= ElapsedDuration)
                {
                    _isRightMove = false;
                }
                else if (!_isRightMove && ElapsedDuration <= 0)
                {
                    _isRightMove = true;

                }
            }

            else
            {
                ElapsedDuration += Time.deltaTime;
                ElapsedDuration = Mathf.Clamp(ElapsedDuration, 0, TotalDuration);

                //���� ��� �ð��� �� ����ð��� �Ѿ�����
                if (TotalDuration <= ElapsedDuration)
                {

                    OnComplete?.Invoke();
                    OnComplete = null;

                    if (0 < DataSequences.Count)
                    {
                        ElapsedDuration = 0;
                        SetData(DataSequences.Dequeue());
                    }
                    else
                    {
                        TweenCompleted();
                        enabled = false;
                    }
                }
            }
          
        }


        /// <summary>Tween�ִϸ��̼��� ����� ��� �ҷ��� �Լ� </summary>
        protected virtual void TweenCompleted()
        {
        }


        public void AddDataSequence(DataSequence dataSequence)
        {
            DataSequences.Enqueue(dataSequence);
        }


        //��ӿ
        private float Constant(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            return percent;
        }


        private float Quadratic(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent;
            return percent;
        }


        private float Smoothstep(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * (3f - 2f * percent);
            return percent;
        }


        private float Smootherstep(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * percent * (percent * (6f * percent - 15f) + 10f);
            return percent;
        }


        private float Spike(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            if(elapsedDuration <= totalDuration * 0.5f)
                return  Mathf.Pow(percent/ 0.5f, 3);

            return Mathf.Pow((1 - percent) / 0.5f, 3);
        }


        private float EaseInOutElastic(float elapsedDuration, float totalDuration)
        {
            float c = (2 * Mathf.PI) / 4.5f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0
            ? 0
            : percent == 1
            ? 1
            : percent < 0.5f
            ? -(Mathf.Pow(2, 20 * percent - 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2
            : (Mathf.Pow(2, -20 * percent + 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2 + 1;

        }


        private float EaseInOutBack(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;
            return percent < 0.5f
               ? (Mathf.Pow(2 * percent, 2) * ((c2 + 1) * 2 * percent - c2)) / 2
               : (Mathf.Pow(2 * percent - 2, 2) * ((c2 + 1) * (percent * 2 - 2) + c2) + 2) / 2;
        }


        //sin�׷���ó�� ������
        private float Sinerp(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Sin(percent * Mathf.PI * 0.5f);
            return percent;
        }


        //cos�׷���ó�� ������
        private float Coserp(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Cos(percent * Mathf.PI * 0.5f);
            return percent;
        }
    }
}
