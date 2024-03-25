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

    private bool _isAnimating;

    public void StartAnimation()
    {
      if (_isAnimating is false)
        StartCoroutine(LerpSliderValue());
    }

    private IEnumerator LerpSliderValue()
    {
      _isAnimating = true;
      float elapsedTime = 0f;

      while (elapsedTime < _fillDuration)
      {
        elapsedTime += Time.deltaTime;
        _slider.value = _statusCurve.Evaluate(elapsedTime / _fillDuration);
        yield return null;
      }

      _slider.value = 0f;
      _isAnimating = false;
    }
  }
}