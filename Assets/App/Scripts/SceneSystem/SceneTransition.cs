using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.SceneSystem
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _fadeCanvasGroup;
        [SerializeField] private float _fadeDuration = .5f;

        private void Awake()
        {
            _fadeCanvasGroup.blocksRaycasts = true;
            _fadeCanvasGroup.alpha = 1f;
            _fadeCanvasGroup.DOFade(0f, _fadeDuration)
                .OnComplete(() => _fadeCanvasGroup.blocksRaycasts = false);
        }

        public void TransitionToScene(string sceneName)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                Debug.LogError($"Scene {sceneName} is already active");
                return;
            }

            _fadeCanvasGroup.blocksRaycasts = true;
            _fadeCanvasGroup.DOFade(1f, _fadeDuration)
                .OnComplete(() => OnFadeCompleted(sceneName));
        }

        private void OnFadeCompleted(string sceneName)
        {
            try
            {
                SceneManager.LoadSceneAsync(sceneName);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
