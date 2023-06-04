using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Color firstPlayerPickedColor;
    public Color secondPlayerPickedColor;


    [SerializeField] private Color[] playerColors;
    [SerializeField] private Toggle[] toggles;

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    
    private void Start()
    {
        firstPlayerPickedColor = playerColors[0];
        secondPlayerPickedColor = playerColors[3];
    }

    private void Update()
    {
        for(int i = 0; i < toggles.Length; i++) {
            if (toggles[i].isOn) {
                if(i < 3) {
                    firstPlayerPickedColor = playerColors[i];
                } else if(i > 2) {
                    secondPlayerPickedColor = playerColors[i];
                }
            }
        }
    }
}
