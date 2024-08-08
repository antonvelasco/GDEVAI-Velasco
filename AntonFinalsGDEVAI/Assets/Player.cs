using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [Range(100f, 100f)]
    [SerializeField] private float lookSensitivity;
    private float xMove;
    private float zMove;
    [SerializeField] private GameObject Ccamera;
    [SerializeField] private GameObject CcameraFollow;
    private void Update()
    {
        Move();
        Look();
    }
    private void Move()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Vector3 cameraForward = Ccamera.transform.forward;
        Vector3 cameraRight = Ccamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        Vector3 forwardRelative = zMove * cameraForward;
        Vector3 rightRelative = xMove * cameraRight;
        Vector3 moveDirection = forwardRelative + rightRelative;
        moveDirection.Normalize();
        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);
        if (moveDirection != Vector3.zero)
            transform.forward = moveDirection;
    }
    private void Look()
    {
        Ccamera.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime);
        Ccamera.transform.LookAt(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
        CcameraFollow.transform.eulerAngles = new Vector3(0, 0, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public float GetSpeed() { return speed; }
}