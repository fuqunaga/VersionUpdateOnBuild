using UnityEngine;

namespace VersionUpdateOnBuild
{
    /// <summary>
    /// VersionUpdateOnBuildParameter
    /// see also VersionUpdateOnBuild.cs
    /// </summary>
    [CreateAssetMenu(menuName = "VersionUpdateOnBuildParameter", fileName = "VersionUpdateOnBuildParameter", order = 10000)]
    public class VersionUpdateOnBuildParameter : ScriptableObject
    {
        public bool ignoreDevelopmentBuild = true;

        [Tooltip("magic word: %[datetime_format]% -> DateTime.Now.ToString(\"datetime_format\")")]
        public string format = "%yy/MM/dd HH:mm%";
    }
}