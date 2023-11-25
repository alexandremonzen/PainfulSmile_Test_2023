using UnityEngine;

public sealed class FollowGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _targetToFollow;

    private void Update()
    {
        this.transform.position = _targetToFollow.transform.position;
    }
}
