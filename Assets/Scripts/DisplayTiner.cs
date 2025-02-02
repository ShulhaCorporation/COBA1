using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTiner : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    private TextMeshProUGUI time;
    private string zero;
    // Start is called before the first frame update
    void Start()
    {    time = GetComponent<TextMeshProUGUI>();
        timer.OnTick += TimerOnTick;
    }

    private void TimerOnTick()
    {
        zero = "";
        int seconds = timer.GetSeconds();
        int minutes = seconds / 60;
        seconds -= minutes * 60;
        if (seconds < 10)
        {
            zero = "0";
        }
        time.SetText($"{minutes}:{zero}{seconds}");
        if( minutes <= 0 && seconds <= 0)
        {
            gameObject.SetActive( false );
        }
    }

   
}
