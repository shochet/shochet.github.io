using UnityEngine;
using System;
using System.Collections;
using Parse;
using UnityEngine.UI;

public class ParseTest : MonoBehaviour
{
    public Text label;
    
    private void Start()
    {
        label.text = "Initializing...";
        StartCoroutine(HandleParseConfig());
    }
    
    private IEnumerator HandleParseConfig()
    {
        // Wait for parse setup
        yield return new WaitForSeconds(1f);

        var task = ParseConfig.GetAsync();
        while (!task.IsCompleted) yield return null;

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.Log("fault");
            label.text = $"fault {task.Exception.ToString()}";
        }
        else
        {
            var parseConfig = (ParseConfig)task.Result;
            var serverVersion = parseConfig.Get<int>("serverVersion");
            Debug.Log($"serverVersion = {serverVersion}");
            label.text = $"serverVersion = {serverVersion}";
        }
    }
}