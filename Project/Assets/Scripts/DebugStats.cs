using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Profiling;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Text;
using TMPro;

public class DebugStats : MonoBehaviour
{
    string _statsText;
    ProfilerRecorder _totalReservedMemoryRecorder;

    void Start()
    {
         _totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
    }

    void Update()
    {
        var sb = new StringBuilder(500);
        if (_totalReservedMemoryRecorder.Valid)
            sb.AppendLine($"Memory: {_totalReservedMemoryRecorder.LastValue / 1024 / 1024} MB");
        _statsText = sb.ToString();

        transform.GetComponent<TextMeshProUGUI>().text = "FPS: " + (int)(1f / Time.unscaledDeltaTime) + "\n"+ _statsText;
    }

    void OnDisable()
    {
        _totalReservedMemoryRecorder.Dispose();
    }
}
