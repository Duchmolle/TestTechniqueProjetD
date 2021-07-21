using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Text _timerDisplay;
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private Canvas _deadCanvas;
    [SerializeField] private Canvas _winCanvas;

    private void Awake()
    {
        _loosePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (TimeLeft())
        {
            _timerDisplay.text = "Il reste " + (int)_timer + " secondes avant que l'aventurier n'arrive à s'enfuir";
        }
        else
        {
            _timerDisplay.text = "";
            _loosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public bool TimeLeft()
    {
        return _timer > 0;
    }

    public void WinCanvas()
    {
        _winCanvas.gameObject.SetActive(true);
    }

    public void DeadScreen()
    {
        _deadCanvas.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
