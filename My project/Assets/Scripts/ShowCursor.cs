using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    public bool showCursor;

    void Start()
    {
        if (showCursor == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
