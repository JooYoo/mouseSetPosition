using UnityEngine;

public class SetPosition : MonoBehaviour
{
    private GameObject Cube;
    private bool pinHere = false;
    private bool IsRotate = false;
    private float mousePositionZ = 10;

    void Start()
    {
        Cube = GameObject.Find("TheCube");
    }

    void Update()
    {
        IsRotate = false;

        if (Input.GetKeyDown(KeyCode.Return)) // Enter: pin object here
        {
            pinHere = !pinHere;
        }

        // Obj Rotation 
        if (Input.GetMouseButton(1)) // MouseRight: active 
        {
            IsRotate = true;

            if (Input.GetAxis("Mouse X") < 0) // Mouse movement left
            {
                Cube.transform.Rotate(Vector3.up);
            }
            if (Input.GetAxis("Mouse X") > 0) // Mmouse movement right
            {
                Cube.transform.Rotate(-Vector3.up);
            }
        }

        // Obj Position
        if (!pinHere && !IsRotate)
        {
            // get mouse position
            var mousePosition = Input.mousePosition;
            mousePosition.z = mousePositionZ;
            // move on X and Y
            Cube.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            // move on Z
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // scroll forward
            {
                mousePositionZ = mousePositionZ + 1;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // scroll backwards
            {
                mousePositionZ = mousePositionZ - 1;
            }
        }
    }
}
