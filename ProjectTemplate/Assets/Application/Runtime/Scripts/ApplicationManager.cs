using UnityEngine;
using UnityEngine.SceneManagement;

namespace Company.ProjectTemplate
{
    internal static class ApplicationManager
    {
        internal static ApplicationSettings ApplicationSettings { get; private set; }

        private static bool isInitialized;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialize()
        {
#if UNITY_EDITOR
            // Only initialize application manager if the playmode scene is the default base scene.
            if (UnityEditor.EditorBuildSettings.scenes is { Length: > 0 })
            {
                var playmodeScene = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEditor.SceneAsset>(SceneManager.GetActiveScene().path);
                var defaultScene = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEditor.SceneAsset>(UnityEditor.EditorBuildSettings.scenes[0].path);

                if (playmodeScene != defaultScene)
                {
                    return;
                }
            }
#endif
            if (isInitialized) { return; }
            isInitialized = true;

            ApplicationSettings = Resources.Load<ApplicationSettings>(nameof(ApplicationSettings));

            if (ApplicationSettings == null)
            {
                Debug.LogError($"Failed to load {nameof(ApplicationSettings)}!");
                return;
            }

            // TODO Instantiate any prefabs
        }
    }
}
