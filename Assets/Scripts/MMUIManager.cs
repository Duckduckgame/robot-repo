using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MMUIManager : MonoBehaviour
{
    Button start;
    Button quit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPressed()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
