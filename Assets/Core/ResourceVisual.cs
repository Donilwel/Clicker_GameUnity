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
            ResourceBank rb = _manager.GetResourceBank();
            var resourses = (GameResource[])Enum.GetValues(typeof(GameResource));

            for (int i = 0; i < resourses.Length; ++i)
            {
                int copyI = i;
                rb.GetResource(resourses[i]).OnValueChanged += newValue => UpdateResourceVisual(copyI, newValue);

                UpdateResourceVisual(copyI, rb.GetResource(resourses[i]).Value);
            }
        }

        private void UpdateResourceVisual(int textIndex, int newValue)
        {
            _resourceTexts[textIndex].text = newValue.ToString();
        }
    }
}