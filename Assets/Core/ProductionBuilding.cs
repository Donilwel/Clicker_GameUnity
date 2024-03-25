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

        [Header("Production Settings")]
        [SerializeField]
        private int _productionValue;

        [SerializeField] private GameResource _productionResource;

        [Space(5)]
        [Header("Functional Settings")]
        [SerializeField]
        private GameManager _manager;

        [SerializeField] private SliderAnimation _sliderAnimation;
        public Action<float> OnProductionTimeChanged
        {
            get;
            set;
        }
        private ResourceBank _bank;
        private bool _inProduction;

        public ObservableInt GetProductionLevel()
        {
            return _productionLevel;
        }

        private void Start()
        {
            OnProductionTimeChanged += _sliderAnimation.ChangeFillDuration;
            _bank = _manager.GetResourceBank();
            CalculateProductionTime();
        }

        private const float DECREASING_TIME_SPEED = 6f;

        private void CalculateProductionTime()
        {
            _productionTime = 3 * Mathf.Exp(-_productionLevel.Value / DECREASING_TIME_SPEED);
        }

        public void IncreaseProductionLevel()
        {
            ++_productionLevel.Value;
            CalculateProductionTime();
            OnProductionTimeChanged.Invoke(_productionTime);
        }

        public void StartProduction()
        {
            if (!_inProduction)
                StartCoroutine(FinishProduction());
        }

        private IEnumerator FinishProduction()
        {
            _inProduction = true;
            yield return new WaitForSeconds(_productionTime);
            _bank.ChangeResource(_productionResource, _productionValue);
            _inProduction = false;
        }
    }
}