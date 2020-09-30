using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TimeDestructor : MonoBehaviour
{
    [SerializeField]
    float destroyAfter;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = this.gameObject.AddComponent<Timer>();
        timer.IsFixed = true;
        timer.FixedTime = destroyAfter;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.IsRunning)
            Destroy(gameObject);
    }
}
