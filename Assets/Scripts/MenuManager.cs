using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManagerInstance;

    public bool gameState;
    public GameObject menuElements;
    void Start()
    {
        gameState = false;
        menuManagerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTheGame()
    {
        gameState = true;
        menuElements.SetActive(false);
    }
}
