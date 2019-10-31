using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPauseHandler : MonoBehaviour
{
    enum UIMode {play, pause }
    UIMode crntMode = UIMode.play;
    UIMode oldMode = UIMode.play;

    [SerializeField]
    CanvasGroup pauseCanvas;
    [SerializeField]
    CanvasGroup playCanvas;
    [SerializeField]
    TextMeshProUGUI boidCounter;
    [SerializeField]
    CanvasGroup winCanvas;

    Dictionary<UIMode, CanvasGroup> modeToCanvas;

    [SerializeField]
    BoidController boidController;

    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        modeToCanvas = new Dictionary<UIMode, CanvasGroup>();
        modeToCanvas.Add(UIMode.play, playCanvas);
        modeToCanvas.Add(UIMode.pause, pauseCanvas);

        //boidController = FindObjectOfType<BoidController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (win) winCanvas.alpha = 1;
        if (Input.GetKeyDown(KeyCode.Escape) && crntMode == UIMode.play)
        {
            crntMode = UIMode.pause;
            Time.timeScale = 0.1f;
        }


        if(crntMode != oldMode)
        {
            SwitchModes();
        }

        oldMode = crntMode;

        boidCounter.text = "Controled Drones: " + boidController.boidList.Count;
    }

    void SwitchModes()
    {
        modeToCanvas[oldMode].alpha = 0;
        modeToCanvas[oldMode].blocksRaycasts = false;
        modeToCanvas[oldMode].interactable = false;
        modeToCanvas[crntMode].alpha = 1;
        modeToCanvas[crntMode].blocksRaycasts = true;
        modeToCanvas[crntMode].interactable = true;
        oldMode = crntMode;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        crntMode = UIMode.play;
        Time.timeScale = 1;

    }
}
