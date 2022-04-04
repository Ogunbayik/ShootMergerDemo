using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public Animator animator;
    public GameObject gameOverUI;
    public GameObject player;
    public Text powerText;
    public int bulletDamage;


    public static Collector collectorInstance;
    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = 10;
        collectorInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = "Power: " + bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            bulletDamage += 10;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetTrigger("Obstacle");
            gameOverUI.SetActive(true);
            player.SetActive(false);

        }
    }
}
