using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [Header("Player Settings")]
    [Range(1, 10)]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float backPower = 4f;

    private Camera cam;
    private Rigidbody playerRb;

    private void Awake()
    {
        cam = Camera.main;
        playerRb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        cam.transform.position = transform.position + new Vector3(0, 5f, -4f);

        if (MenuManager.menuManagerInstance.gameState)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wheel"))
        {
            Debug.Log("wheel collided");
            playerRb.AddForce((transform.position - collision.transform.position) * backPower, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            speed *= 2;
        }
        else if(collision.gameObject.CompareTag("Pass"))
        {
            Debug.Log("Next Level!");
        }
    }
}
