using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CommandProcessor))]
public class Entity : MonoBehaviour, IEntity {

    private InputReader _inputReader;
    private CommandProcessor _commandProcessor;

    private void Awake()
    {
        
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();

    }

    private void Update()
    {
        var direction = _inputReader.ReadInput();
        if(direction != Vector3.zero)
        {
            // allocating memory every time we do a command
            // every frame we move
            var moveCommand = new MoveCommand(this, direction, transform.position);
            _commandProcessor.ExecuteCommand(moveCommand);
        }
        if(_inputReader.ReadUndo())
        {
            _commandProcessor.Undo();
        }    
        if(_inputReader.ReadRedo())
        {
            _commandProcessor.Redo();
        }
    }

    public void MoveFromTo(Vector3 start, Vector3 end)
    {

    }
}
