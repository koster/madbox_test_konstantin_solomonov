using System.Collections.Generic;
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
    public static int level;

    public PlayerCharacter pc;
    public UI ui;
    public GameCamera gameCamera;

    public List<GameObject> levels;

    GameState state;

    void Awake()
    {
        state = GameState.ACTION;
        instance = this;
    }

    void Start()
    {
        if (level >= levels.Count)
            level = 0;
        
        for (var i = 0; i < levels.Count; i++)
            levels[i].SetActive(i == level);
    }

    void Update()
    {
        if (state != GameState.ACTION)
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(0);
    }

    public void Win()
    {
        if (state != GameState.ACTION)
            return;

        gameCamera.mode = CameraMode.WIN;
        state = GameState.WIN;
        ui.Win();

        level++;
    }

    public void Loss()
    {
        if (state != GameState.ACTION)
            return;

        state = GameState.LOSS;
        ui.Loss();
    }
}