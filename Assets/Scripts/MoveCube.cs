using UnityEngine;
using System.Diagnostics;

public class MoveCube : MonoBehaviour {
    private int direction;
    private float x;

    // Use this for initialization
    void Awake () {
        direction = 1;
        x = -4.0f;
    }

    // Update is called once per frame
    void Update () {
        Stopwatch sw = Stopwatch.StartNew();
        if (x >= 4) {
            direction = -1;
        } else if (x < -4) {
            direction = 1;
        }
        x += .2f * direction * (Time.deltaTime * 100);
        this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
        sw.Stop();
        UnityEngine.Debug.Log("C#: " + sw.Elapsed.TotalMilliseconds);
    }
}
