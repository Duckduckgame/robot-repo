using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    
    BoidController boidController;

    [SerializeField]
    TextMeshProUGUI boidsNumTxt;

    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        if (boidsNumTxt == null)
        {
            boidsNumTxt = FindObjectOfType<TextMeshProUGUI>(); // FindObjectOfType<TextMeshPro>().GetComponent<TextMeshPro>();
        }


        boidController = FindObjectOfType<BoidController>().GetComponent<BoidController>();
                
    }

    // Update is called once per frame
    void Update()
    {
        int boidsNum;
#if false
        boidsNum = boidController.boidList.Count;
#endif
#if true
        boidsNum = 69;
#endif

        boidsNumTxt.SetText("ROBO REVO BOYOS NUM: " + boidsNum);
    }
}
