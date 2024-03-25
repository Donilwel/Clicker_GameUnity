using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    public class SliderAnimation : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        [SerializeField] private AnimationCurve _statusCurve;
        [SerializeField] private float _fillDuration = 2f;


        public void ChangeFillDuration(float newDuration)
        {
            _fillDuration = newDuration;
        }

        private bool checker;

        public void StartAnimation()
        {
            if (!checker)
                StartCoroutine(LerpSliderValue());
        }

        private IEnumerator LerpSliderValue()
        {
            checker = true;
            float timer = 0f;

            while (timer < _fillDuration)
            {
                timer += Time.deltaTime;
                _slider.value = _statusCurve.Evaluate(timer / _fillDuration);
                yield return null;
            }

            _slider.value = 0f;
            checker = false;
        }
    }
}