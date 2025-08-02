using UnityEngine;

public class CreateGO : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public void CreateGOAtThisPos()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
