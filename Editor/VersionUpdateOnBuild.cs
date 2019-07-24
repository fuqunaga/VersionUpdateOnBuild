using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace VersionUpdateOnBuild
{
    /// <summary>
    /// Set PlayerSettings.bundleVersion OnPreprocessBuild
    /// from VersionupdateOnBuildParameter.format
    /// 
    /// Edit the VersionupdateOnBuildParameter.asset
    /// </summary>
    public class VersionUpdateOnBuild : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            var guid = AssetDatabase.FindAssets("t:VersionUpdateOnBuildParameter").FirstOrDefault();
            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (path == null) return;

            var param = AssetDatabase.LoadAssetAtPath<VersionUpdateOnBuildParameter>(path);

            if (param.ignoreDevelopmentBuild && ((report.summary.options & BuildOptions.Development) != 0)) return;

            var format = param.format;
            var matches = Regex.Matches(format, @"%.+?%").Cast<Match>();
            var version = matches.Aggregate(format, (str, m) => str.Replace(m.Value, DateTime.Now.ToString(m.Value.Trim('%'))));

            PlayerSettings.bundleVersion = version;
            Debug.Log($"VersionUpdateOnBuild: PlayerSettings.bundleVersion = {version}");
        }
    }
}