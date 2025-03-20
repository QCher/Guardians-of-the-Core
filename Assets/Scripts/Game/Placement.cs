using UnityEngine;

public class Placement : MonoBehaviour
{
    [SerializeField] Transform _characterRoot;
    [Range(0,2)] [SerializeField] private int _id;
    public int Id => _id;

    public void Place(GameObject character)
    {
        character.transform.SetPositionAndRotation(_characterRoot.position, Quaternion.identity);
    }
}
