using UnityEngine;
/// <summary>
/// Set a GO over another GO. Will check height of both and will calculate new pos
/// </summary>
public static class SetOnTopOfGo
{
    public static void SetOnTop(GameObject baseGO, GameObject topGO)
    {
        Collider baseObj = baseGO.GetComponent<Collider>();
        Collider topObj = topGO.GetComponent<Collider>();
        if(baseObj == null || topObj == null ){Debug.LogWarning("BASE or TOP has no COLLIDER"); return;}

        float topHeight = topObj.bounds.size.y;
        float baseHeight = baseObj.bounds.size.y;
        Vector3 newPosition = baseGO.transform.position + new Vector3(0, (topHeight / 2f + baseHeight / 2f), 0);
        topGO.transform.position = newPosition;
    }
}
