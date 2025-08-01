using UnityEngine;

public static class LookAtHelper
{
    public static void LookAtPos(Transform obj, Transform target)
    {
        obj.rotation = GetLookAtPos(obj, target);
    }

    public static void LookAtTargetWithDelay(Transform obj, Transform target, float speed = 5)
    {
        LookAtTargetWithDelay(obj, GetLookAtPos(obj, target), speed);
    }

    public static void LookAtTargetWithDelay(Transform obj, Quaternion target, float speed = 5)
    {
        obj.rotation = Quaternion.Slerp(obj.rotation, target, Time.deltaTime * speed);
    }

    private static Quaternion GetLookAtPos(Transform obj, Transform target)
    {
        Vector3 direction = target.position - obj.position;
        if(direction == Vector3.zero){return Quaternion.identity;}
        return Quaternion.LookRotation(direction);
        
        
    }
}
