using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomBuild
{
    private static string outputProjectsFolder =  "C:\\UnityBuilds\\TestProject";

    static void BuildWindows()
    {
        BuildTarget target = BuildTarget.StandaloneWindows;
        EditorUserBuildSettings.SwitchActiveBuildTarget(target);
        PlayerSettings.applicationIdentifier = "TestBuild_AppID";
        BuildPipeline.BuildPlayer(GetScenes(), string.Format("{0}/{1}.exe" , outputProjectsFolder, PlayerSettings.applicationIdentifier), target, BuildOptions.None);
    }
    static string[] GetScenes()
    {
        var projectScenes = EditorBuildSettings.scenes;
        List<string> scenesToBuild = new List<string>();
        for (int i = 0; i < projectScenes.Length; i++)
        {
            if (projectScenes[i].enabled) {
                scenesToBuild.Add(projectScenes[i].path);
            }
        }
        return scenesToBuild.ToArray();
    }
}
