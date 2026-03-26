using TMPro;
using UnityEngine;
using System.Diagnostics;

public class TextChangeDetector : MonoBehaviour
{
    private TMP_Text _text;
    private string _lastText;
    
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _lastText = _text.text;
    }
    
    void Update()
    {
        if (_text.text != _lastText)
        {
            // Get the calling method info
            StackTrace stackTrace = new StackTrace(true);
            StackFrame[] frames = stackTrace.GetFrames();
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"Text changed from '{_lastText}' to '{_text.text}'");
            sb.AppendLine("Full call stack:");
            
            foreach (StackFrame frame in frames)
            {
                var method = frame.GetMethod();
                var fileName = frame.GetFileName();
                var lineNumber = frame.GetFileLineNumber();
                
                if (fileName != null && !fileName.Contains("TextChangeDetector"))
                {
                    sb.AppendLine($"  {method.DeclaringType}.{method.Name} at {fileName}:{lineNumber}");
                }
            }
            
            UnityEngine.Debug.Log(sb.ToString());
            _lastText = _text.text;
        }
    }
}