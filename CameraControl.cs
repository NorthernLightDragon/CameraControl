using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float panSpeed = 30f;
    public float windowEdgeBorder = 10f;

    [Header("CameraLimits")]
    public float leftLimit = 0f;
    public float rightLimit = 70f;
    public float upLimit = 65f;
    public float downLimit = -4f;

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.mousePosition.y;
        float mouseX = Input.mousePosition.x;

         //Camera controls in this next condition after we check that the mouse is within the window
        if (mouseX >= 0 && mouseX <= Screen.width &&
            mouseY >= 0 && mouseY <= Screen.height)
        {
            // up with 'w' movement
            if ((Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || mouseY >= Screen.height - windowEdgeBorder) &&
                transform.position.z < upLimit)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            // left with 'a' movement
            if ((Input.GetKey("a") ||Input.GetKey(KeyCode.LeftArrow) || mouseX <= windowEdgeBorder) &&
                transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            // down with 's' movement
            if ((Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) || mouseY <= windowEdgeBorder) &&
                transform.position.z > downLimit)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            // right with 'd' movement
            if ((Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || mouseX >= Screen.width - windowEdgeBorder) &&
                transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime,
                                    Space.World);
            }
         }
    }
}
