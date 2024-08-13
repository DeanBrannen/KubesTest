using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Builder : MonoBehaviour
{
	[MenuItem("Build/Build WindowsOS")]
	public static void PerformWindowsOSBuild()
	{
		BuildPlayerOptions bpo = new BuildPlayerOptions();
		bpo.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        bpo.locationPathName = "G:/My Drive/Build Pipeline Documentation/TestBuild/Foolin.exe";
		bpo.target = BuildTarget.StandaloneWindows;
		bpo.options = BuildOptions.None;

		BuildReport report = BuildPipeline.BuildPlayer(bpo);
		BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log(message: "Build Succes" + summary.totalSize + " bytes");
        }
        if (summary.result == BuildResult.Failed)
		{
			Debug.Log(message: "Build Succes");
		}



    }
}
