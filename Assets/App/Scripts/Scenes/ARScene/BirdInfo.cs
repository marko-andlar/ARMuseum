using System.Collections.Generic;
using App.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.ARScene
{
    public class BirdInfo : MonoBehaviour
    {
        [SerializeField] private ToggleGroup _toggleGroup;

        // Marko: Should use dictionary after importing package that can display Dictinary in Inspector
        [SerializeField] private List<Toggle> _toggleButtons;
        [SerializeField] private List<CanvasGroupExtension> _pages;
        [SerializeField] private CanvasGroupExtension _background;

        private void Start()
        {
            var buttonCount = _toggleButtons.Count;
            var pageCount = _pages.Count;
            if (buttonCount != pageCount)
            {
                Debug.LogWarning("Button count should be the same as page count");
                return;
            }

            for (var i = 0; i < buttonCount; i++)
            {
                var index = i;
                _toggleButtons[i].onValueChanged.AddListener(isOn => OnButtonToggled(index, isOn));
            }
        }

        private void OnButtonToggled(int buttonIndex, bool isOn)
        {
            _pages[buttonIndex].SetActive(isOn);
            _background.SetActive(_toggleGroup.AnyTogglesOn());
        }
    }
}
