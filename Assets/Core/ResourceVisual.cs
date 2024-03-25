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
        [SerializeField] private GameManager _manager;
        [SerializeField] private List<TMP_Text> _resourceTexts;

        private void Start()
        {
            ResourceBank resourceBank = _manager.GetResourceBank();
            // Get all resources from GameResource
            var allResources = (GameResource[])Enum.GetValues(typeof(GameResource));

            // Assigning resource visual update to all resources
            for (int i = 0; i < allResources.Length; i++)
            {
                int copyI = i;
                resourceBank.GetResource(allResources[i]).OnValueChanged +=
                  newValue => UpdateResourceVisual(copyI, newValue);

                UpdateResourceVisual(copyI, resourceBank.GetResource(allResources[i]).Value);
            }
        }

        private void UpdateResourceVisual(int textIndex, int newValue)
          => _resourceTexts[textIndex].text = newValue.ToString();
    }
}