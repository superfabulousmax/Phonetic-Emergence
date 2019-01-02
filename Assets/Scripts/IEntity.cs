using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
    void MoveFromTo(Vector3 start, Vector3 end);
}
