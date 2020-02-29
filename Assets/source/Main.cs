using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    ACTION,
    WIN,
    LOSS
}

public class Main : MonoBehaviour
{
    public static Main instance;

    public UI ui;
    public GameCamera gameCamera;
    
    GameState state;

    void Awake()
    {
        state = GameState.ACTION;
        instance = this;
    }

    void Update()
    {
        if (state != GameState.ACTION)
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(0);
    }

    public void Win()
    {
        if (state == GameState.WIN)
            return;

        gameCamera.mode = CameraMode.WIN;
        state = GameState.WIN;
        ui.Win();
    }

    public void Loss()
    {
        if (state == GameState.LOSS)
            return;

        state = GameState.LOSS;
        ui.Loss();
    }
}