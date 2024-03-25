using System;
using System.Collections;
using UnityEngine;
using Presentation;

namespace Core
{
  public class ProductionBuilding : MonoBehaviour
  {
    private float _productionTime = 3;
    private readonly ObservableInt _productionLevel = new(0);

    [Header("Production Settings")] [SerializeField]
    private int _productionValue;

    [SerializeField] private GameResource gameResource;

    [Space(5)] [Header("Functional Settings")] [SerializeField]
    private GameManager _manager;
    [SerializeField] private SliderAnimation _sliderAnimation;
    public Action<float> OnProductionTimeChanged { get; set; }
    private ResourceBank _resourceBank;
    private bool _checker;

        public ObservableInt GetProductionLevel()
        {
            return _productionLevel;
        }

    private void Start()
    {
      OnProductionTimeChanged += _sliderAnimation.ChangeFillDuration;
      _resourceBank = _manager.GetResourceBank();
      CalculateProductionTime();
    }
        private void CalculateProductionTime()
        {
            _productionTime = 3 * Mathf.Exp(-_productionLevel.Value / 6f);
        }

    public void IncreaseProductionLevel()
    {
      _productionLevel.Value++;
      CalculateProductionTime();
      OnProductionTimeChanged.Invoke(_productionTime);
    }

    public void StartProduction()
    {
      if (!_checker)
        StartCoroutine(FinishProduction());
    }

    private IEnumerator FinishProduction()
    {
      _checker = true;
      yield return new WaitForSeconds(_productionTime);
      _resourceBank.ChangeResource(gameResource, _productionValue);
      _checker = false;
    }
  }
}