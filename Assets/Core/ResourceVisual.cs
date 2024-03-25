using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace Presentation
{
  [Serializable]
  public class ResourceVisual : MonoBehaviour
  {
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<TMP_Text> _texts;

    private void Start()
    {
      ResourceBank resourceBank = _gameManager.GetResourceBank();
      var allResources = (GameResource[])Enum.GetValues(typeof(GameResource));
      for (int i = 0; i < allResources.Length; ++i)
      {
        int I = i;
        resourceBank.GetResource(allResources[i]).OnValue += newValue => UpdateResourceVisual(I, newValue);

        UpdateResourceVisual(I, resourceBank.GetResource(allResources[i]).Value);
      }
    }

        private void UpdateResourceVisual(int t, int val)
        {
            _texts[t].text = val.ToString();
        }
  }
}