using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JAGameManager : MonoBehaviour
{
    public static JAGameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool isControlingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isControlingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isControlingPlayer = !isControlingPlayer;
        }
    }
}
