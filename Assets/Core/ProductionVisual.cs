using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace Presentation
{
  public class ProductionVisual : MonoBehaviour
  {
    [SerializeField] private List<TMP_Text> _texts;
    [SerializeField] private List<ProductionBuilding> _producrionBuilding;

    private void Start()
    {
      for (int i = 0; i < _producrionBuilding.Count; ++i)
      {
        int I = i;
        _producrionBuilding[i].GetProductionLevel().OnValue += (newValue =>_texts[I].text = newValue.ToString());
        _producrionBuilding[i].GetProductionLevel().OnValue.Invoke(_producrionBuilding[i].GetProductionLevel().Value);
      }
    }
  }
}