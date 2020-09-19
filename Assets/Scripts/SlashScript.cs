using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{

    public int EXIST_TIME;
    private int current_time;
    // Start is called before the first frame update
    void Start()
    {
        current_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        current_time++;
        if (current_time == EXIST_TIME)
            Destroy(this.gameObject);
    }
}
