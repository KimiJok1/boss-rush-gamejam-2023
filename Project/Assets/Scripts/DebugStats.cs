using System.Collections;
using System.Collections.Generic;

using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Text;
using TMPro;

/*
    Unity has all of this built-in
*/

public class DebugStats : MonoBehaviour
{
    string _statsText;
    ProfilerRecorder _totalReservedMemoryRecorder;

    public float updateTime = 1.1f;
    public float updateFrequency = 1f;

    void Start()
    {
         _totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
    }

    void Update()
    {
        updateTime += Time.deltaTime * 100;
        if (updateTime < updateFrequency)
            return;

        updateTime = 0f;

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
