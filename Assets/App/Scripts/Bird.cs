using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Vuforia;

namespace App.Scripts
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private ImageTargetBehaviour _imageTarget;
        [SerializeField] private AssetReferenceGameObject _assetReference;
        private GameObject _birdModel;

        private void Awake()
        {
            _assetReference
                .InstantiateAsync(transform)
                .Completed += OnModelInstantiated;
        }

        private void OnDestroy()
        {
            _assetReference.ReleaseInstance(_birdModel);
        }

        private void OnTargetStatusChanged(ObserverBehaviour observer, TargetStatus targetStatus)
        {
            if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
                _birdModel.SetActive(true);
            else
                _birdModel.SetActive(false);
        }

        private void OnModelInstantiated(AsyncOperationHandle<GameObject> operationHandle)
        {
            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _birdModel = operationHandle.Result;
                _birdModel.SetActive(false);
                _imageTarget.OnTargetStatusChanged += OnTargetStatusChanged;
            }
            else
            {
                Debug.LogError("Failed to instantiate bird model");
            }
        }
    }
}
