using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

[System.Serializable]
public class PythonScript : MonoBehaviour {
    private Interpreter machine = new Interpreter();

    private object ClassReference;

    /// <summary>
    /// The path of file
    /// </summary>  
    public string FilePath;

    /// <summary>
    /// The lib path.
    /// </summary>
    public static List<string> SysPath = new List<string>();

    /// <summary>
    /// Reset this instance.
    /// </summary>
    public void Reset() {
        FilePath = string.Empty;
    }

    private void Awake() {
        if (FilePath != string.Empty) {
            machine.Compile(FilePath, Microsoft.Scripting.SourceCodeKind.Statements);
            ClassReference = machine.GetVariable(Path.GetFileNameWithoutExtension(FilePath));
        }
        InvokeMethod("Awake");
    }

    private void Start() {
        InvokeMethod("Start");
    }

    private void Update() {
        Stopwatch sw = Stopwatch.StartNew();
        InvokeMethod("Update");
        sw.Stop();
        UnityEngine.Debug.Log("Python: " + sw.Elapsed.TotalMilliseconds);
    }

    private void InvokeMethod(string Method) {
        machine.InvokeMethod(ClassReference, Method, this);
    }
}
