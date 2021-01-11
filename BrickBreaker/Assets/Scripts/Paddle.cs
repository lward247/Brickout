using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    // keycode variables for detection of keypress input
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;

    // boolean variables for detection of whether the paddle can move 
    bool canMoveRight = true;
    bool canMoveLeft = true;

    // float variables which determine the speed and direction of the paddle
    public float speed = 0.2f;
    float direction = 0.0f;

    // fixed update function to determine position and speed of paddle
    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }

    // update function to detect keypress input
    void Update()
    {
        // boolean variable to detect which keys are pressed
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isLeftPressed = Input.GetKey(moveLeftKey);

        // if statements to detect if the paddle can move and what direction to move in
        // set direction for right
        if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }

        // set direction for left 
        else if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }

        // set direction for no direction or collision occurs
        else
        {
            direction = 0.0f;
        }
    }

    // collision detection for paddle hitting the left and right walls
    void OnCollisionEnter2D(Collision2D other)
    {
        // switch statement checks the paddle can move left or right
        switch (other.gameObject.name)
        {
            case "Right Wall":
                canMoveRight = false;
                break;

            case "Left Wall":
                canMoveLeft = false;
                break;
        }
    }

    // collision detection for paddle moving away from the left and right walls
    void OnCollisionExit2D(Collision2D other)
    {
        // switch statements checks the paddle is away from the left and right walls
        switch (other.gameObject.name)
        {
            case "Right Wall":
                canMoveRight = true;
                break;

            case "Left Wall":
                canMoveLeft = true;
                break;
        }
    }
}
