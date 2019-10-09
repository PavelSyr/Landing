using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class BuildSetup
{
    [MenuItem("Utils/Settings/ToProd")]
    public static void SetupProdBuild()
    {
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.ich.game.Langin");
        PlayerSettings.bundleVersion = "1.0.6";
        PlayerSettings.Android.bundleVersionCode = 6;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel19;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        PlayerSettings.Android.preferredInstallLocation = AndroidPreferredInstallLocation.Auto;
        PlayerSettings.Android.keystoreName = Application.dataPath + "/../Resources/Cert/user.keystore";
        PlayerSettings.Android.keystorePass = "123123";
        PlayerSettings.Android.keyaliasName = "landing";
        PlayerSettings.Android.keyaliasPass = "123123";
    }
}
