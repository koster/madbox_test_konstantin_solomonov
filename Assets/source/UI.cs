using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject winUI;
    public GameObject lossUI;

    void Start()
    {
        winUI.SetActive(false);
        lossUI.SetActive(false);
    }

    public void Win()
    {
        winUI.SetActive(true);
    }

    public void Loss()
    {
        lossUI.SetActive(true);
    }
}