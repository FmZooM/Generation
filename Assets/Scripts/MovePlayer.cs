using UnityEngine;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 200f;

    float xRotation = 0f;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; // скрываем и фиксируем курсор
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(1,0,0) * Time.deltaTime * speed);
        //    //gameObject.SetActive(false);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * -speed);

        //}

        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * v);

        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * h);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * -speed);
        }
        // Вращение мышью:

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y + mouseX, 0f);





    }



}
