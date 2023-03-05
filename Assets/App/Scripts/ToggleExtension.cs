using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace App.Scripts
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleExtension : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onToggledOn;
        [SerializeField] private UnityEvent _onToggledOff;

        private void Awake()
        {
            var toggle = GetComponent<Toggle>();
            if (toggle == null)
            {
                Debug.LogError("Toggle component is missing");
                return;
            }

            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            if (isOn)
                _onToggledOn?.Invoke();
            else
                _onToggledOff?.Invoke();
        }
    }
}
