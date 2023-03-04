using UnityEngine;

namespace App.Scripts
{
    public class Follow : MonoBehaviour
    {
        [field: SerializeField] public Transform Target { get; set; }
        [field: SerializeField] public float LerpSpeed { get; set; } = .1f;
        [field: SerializeField] public bool FollowOnAwake { get; set; }

        public bool IsFollowing { get; set; }

        private void Awake()
        {
            if (FollowOnAwake) IsFollowing = true;
        }

        private void Update()
        {
            if (!IsFollowing) return;

            transform.SetPositionAndRotation(
                Vector3.Lerp(transform.position, Target.position, LerpSpeed),
                Quaternion.Slerp(transform.rotation, Target.rotation, LerpSpeed)
            );
        }
    }
}
