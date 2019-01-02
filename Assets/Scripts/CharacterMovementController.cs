using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {

    public float moveSpeed = 30f;
    public float offset = 0.05f;
    public bool following;
    public bool isSelected;
    private float player_width;
    private float player_height;
    private float CLAMP_X;
    private float CLAMP_Y;
    private float CLAMP_OFFSET;
    // Use this for initialization
    void Start()
    {
        following = false;
        isSelected = false;
        player_width = this.GetComponent<Transform>().lossyScale.x;
        player_height = this.GetComponent<Transform>().lossyScale.y;
        offset += 10f;
        CLAMP_X = player_width / Screen.width;
        CLAMP_Y = player_height / Screen.height;
        CLAMP_OFFSET = 0.015f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).magnitude <= offset))
        {
            if (following)
            {
                following = false;
            }
            else
            {
                following = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(following)
            {
                following = false;
            }
        }
        if (following)
        {
            isSelected = true;
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
          
        }
        else
        {
            isSelected = false;

        }

        // clamp movement to screen boundaries
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, CLAMP_X + CLAMP_OFFSET, 1 - CLAMP_X - CLAMP_OFFSET);
        pos.y = Mathf.Clamp(pos.y, CLAMP_Y + CLAMP_OFFSET, 1 - CLAMP_Y - CLAMP_OFFSET);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
