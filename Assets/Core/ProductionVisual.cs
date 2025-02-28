using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace Presentation
{
    public class ProductionVisual : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _productionTexts;
        [SerializeField] private List<ProductionBuilding> _buildings;

        private void Start()
        {
            for (int i = 0; i < _buildings.Count; ++i)
            {
                int j = i;
                _buildings[i].GetProductionLevel().OnValueChanged += (newValue => _productionTexts[j].text = newValue.ToString());
                _buildings[i].GetProductionLevel().OnValueChanged.Invoke(_buildings[i].GetProductionLevel().Value);
            }
        }
    }
}