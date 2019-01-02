using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour {

    public float moveSpeed = 30f;
    public float offset = 0.05f;
    private bool following;
    private float player_width;
    private float player_height;
    private float CLAMP_X;
    private float CLAMP_Y;
    private float CLAMP_OFFSET;

    void Start()
    {
        following = false;
        player_width = this.GetComponent<Transform>().lossyScale.x;
        player_height = this.GetComponent<Transform>().lossyScale.y;
        offset += 10f;
        CLAMP_X = player_width / Screen.width;
        CLAMP_Y = player_height / Screen.height;
        CLAMP_OFFSET = 0.015f;
    }

    public Vector3 ReadInput()
    {
        if (Input.GetMouseButtonDown(0) && ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).magnitude <= offset))
        {
            if (following) following = false;
            else following = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (following) following = false;
        }
        if (following)
        { 
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return worldMousePosition;
        }
       
        return Vector3.zero;
    }

    private void ClampMovement()
    {
        // clamp movement to screen boundaries
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, CLAMP_X + CLAMP_OFFSET, 1 - CLAMP_X - CLAMP_OFFSET);
        pos.y = Mathf.Clamp(pos.y, CLAMP_Y + CLAMP_OFFSET, 1 - CLAMP_Y - CLAMP_OFFSET);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public bool ReadUndo()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool ReadRedo()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
