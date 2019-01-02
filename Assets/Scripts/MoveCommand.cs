using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _direction;
    private Vector3 _originalPosition;
    private float moveSpeed = 1f;

    public MoveCommand(IEntity entity, Vector3 direction, Vector3 originalPosition) : base(entity)
    {
        _direction = direction;
        _originalPosition = originalPosition;
    }

    public override void Execute()
    {
        _entity.transform.position = Vector2.Lerp(_entity.transform.position, _direction, moveSpeed);
    }

    public override void Undo()
    {
        _entity.transform.position = Vector2.Lerp(_entity.transform.position, _originalPosition, moveSpeed);
    }
}
