using UnityEngine;

namespace GameMain.Scripts.Utility
{
    public static class PathManager
    {
        public static string GetSceneAsset(string assetName)
        {
            return $"Assets/GameMain/Scenes/{assetName}.unity";
        }
        
        public static string GetLevelAsset(string assetName)
        {
            return $"Assets/GameMain/Scenes/Levels/{assetName}.unity";
        }

        public static string GetEntityAsset(string assetName)
        {
            return $"Entity/{assetName}";
        }

        public static string GetUIAsset(string assetName)
        {
            return $"UI/{assetName}";
        }
    }
}