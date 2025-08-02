using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _rotationSpeed;

    private Quaternion init;
    private Transform currentTarget;

    private void Start()
    {
        init = transform.rotation;
    }

    void Update()
    {
        if (!currentTarget)
        {
            LookAtHelper.LookAtTargetWithDelay(transform, init, _rotationSpeed);
            return;
        }
        LookAtHelper.LookAtTargetWithDelay(transform, currentTarget, _rotationSpeed);
    }

    public void ChangeTarget(Transform target)
    {
        currentTarget = target;
    }
}
