using UnityEngine;

namespace App.Scripts.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupExtension : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null) Debug.LogError("CanvasGroup component is missing");
        }

        public void SetActive(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}
