using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class FolderStructure : EditorWindow
{
    [MenuItem("MR SINGH/CreateFolder/_Honeywell")]
    static void _Honeywell()
    {
       AssetDatabase.CreateFolder("Assets", "Application");
       AssetDatabase.CreateFolder("Assets/Application", "_Scenes");
       AssetDatabase.CreateFolder("Assets/Application", "Customs");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Packages");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Particles");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Prefabs");
       AssetDatabase.CreateFolder("Assets/Application/Customs/Prefabs", "Exports");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Materials");

       AssetDatabase.CreateFolder("Assets/Application", "FBX");
       AssetDatabase.CreateFolder("Assets/Application/FBX", "Model");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Blockable");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Environment");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Hotspot");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Ladder otspot");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "layout Environment");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Slot");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Terrain");
       AssetDatabase.CreateFolder("Assets/Application/FBX/Model", "Walkable");

       AssetDatabase.CreateFolder("Assets/Application/FBX", "Animation");
       AssetDatabase.CreateFolder("Assets/Application", "Scripts");
       AssetDatabase.CreateFolder("Assets/Application", "Sounds");
       AssetDatabase.CreateFolder("Assets/Application/Sounds", "Voice Overs");
       AssetDatabase.CreateFolder("Assets/Application/Sounds", "Others");
       AssetDatabase.CreateFolder("Assets/Application", "UI");
       AssetDatabase.CreateFolder("Assets/Application/UI", "Main");
       AssetDatabase.CreateFolder("Assets/Application/UI", "Others");

       AssetDatabase.CreateFolder("Assets", "Resources");
       AssetDatabase.CreateFolder("Assets/Resources", "Imports");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Blockable");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Environment");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Hotspot");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Slot");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Terrain");
       AssetDatabase.CreateFolder("Assets/Resources/Imports", "Walkable");

    }

    [MenuItem("MR SINGH/CreateFolder/Simulanis")]
    static void Simulanis()
    {

       AssetDatabase.CreateFolder("Assets", "Application");
       AssetDatabase.CreateFolder("Assets/Application", "_Scenes");
       AssetDatabase.CreateFolder("Assets/Application", "Customs");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Animations");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Packages");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Particles");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Prefabs");
       AssetDatabase.CreateFolder("Assets/Application/Customs/Prefabs", "Exports");
       AssetDatabase.CreateFolder("Assets/Application/Customs", "Materials");

       AssetDatabase.CreateFolder("Assets/Application", "FBX");
       AssetDatabase.CreateFolder("Assets/Application/FBX", "Model");

       AssetDatabase.CreateFolder("Assets/Application/FBX", "Animation");
       AssetDatabase.CreateFolder("Assets/Application", "Scripts");
       AssetDatabase.CreateFolder("Assets/Application", "Sounds");
       AssetDatabase.CreateFolder("Assets/Application/Sounds", "Voice Overs");
       AssetDatabase.CreateFolder("Assets/Application/Sounds", "Others");
       AssetDatabase.CreateFolder("Assets/Application", "UI");
       AssetDatabase.CreateFolder("Assets/Application/UI", "Main");
       AssetDatabase.CreateFolder("Assets/Application/UI", "Others");
    }

  }