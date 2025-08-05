using UnityEditor;

public class WebGLBuilder
{
    [MenuItem("Build/WebGL")]
    public static void BuildWebGL()
    {
        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            "build/WebGL/WebGL",  // ❗ Должен совпадать с `folder` в workflow
            BuildTarget.WebGL,
            BuildOptions.None
        );
    }
}
