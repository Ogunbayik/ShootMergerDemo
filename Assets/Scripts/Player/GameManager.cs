using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public GameObject bulletPrefab;
    public Transform player;
    [Range(0, 1)]
    public float maxSpeed;
    [Space]
    [SerializeField] private float swipeSpeed;


    private Transform ball;
    private Vector3 startMousePos, startBallPos;
    private bool moveTheBall, startTheGame;
    private Camera mainCam;
    void Start()
    {
        gameManagerInstance = this;
        mainCam = Camera.main;
        ball = transform;
        maxSpeed = 0.5f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MenuManager.menuManagerInstance.gameState)
        {
            moveTheBall = startTheGame = true;
            StartCoroutine(AutoAttack());



            Plane newPlane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlane.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;
            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveTheBall = false;


        }

        if (moveTheBall)
        {
            Plane newPlane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlane.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startMousePos;
                Vector3 DesiredBallPos = mouseNewPos + startBallPos;

                DesiredBallPos.x = Mathf.Clamp(DesiredBallPos.x, -4.5f, 4.5f);  //Border for x-Axis

                var player = transform.position;

                player = new Vector3(Mathf.Lerp(player.x, DesiredBallPos.x, Time.deltaTime * swipeSpeed), player.y, player.z);

                transform.position = player;



            }
        }




    }

    private void LateUpdate()
    {
        if (startTheGame)
        {
            mainCam.transform.position = new Vector3(Mathf.Lerp(mainCam.transform.position.x, transform.position.x, (swipeSpeed - 5f) * Time.deltaTime), player.transform.position.y + 5f, player.transform.position.z - 4f);
        }
    }

    private void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 2), Quaternion.identity);
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnBullet();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
