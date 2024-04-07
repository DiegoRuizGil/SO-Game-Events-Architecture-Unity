/*
    This script is part of the SO Game Events Architecture Project.
    You are free to use, modify, and distribute the code as you want.
    Credit is not required, but it is always appreciated.

    Author: Diego Ruiz Gil
    https://github.com/DiegoRuizGil/SO-Game-Events-Architecture-Unity
*/

#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace GameEvents
{
    public class GameEventsEditorWindow : EditorWindow
    {
        private string classNamespace;
        private string className;
        
        [MenuItem("Game Events/Create New Type Event")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GameEventsEditorWindow),true, "Game Events");
        }
        
        private void OnGUI()
        {
            EditorGUILayout.LabelField("Event Info", EditorStyles.boldLabel);

            classNamespace = EditorGUILayout.TextField("namespace", classNamespace);
            GUILayout.Space(5);
            className = EditorGUILayout.TextField("class name", className);

            GUILayout.Space(20);
            
            if (GUILayout.Button("Generate Scripts"))
            {
                GenerateScripts();
            }
            
        }

        private void GenerateScripts()
        {
            if (className == null)
            {
                Debug.Log("Introduzca el nombre de la clase");
                return;
            }
            
            CreateFolders();
            
            FileInfo eventFileInfo = new FileInfo(EVENTS_FOLDER, EVENT_TEMPLATE, "Event", "UnityEngine");
            GenerateScript(eventFileInfo);
            
            FileInfo listenerFileInfo = new FileInfo(LISTENERS_FOLDER, LISTENER_TEMPLATE, "Listener", "UnityEngine.Events");
            GenerateScript(listenerFileInfo);
            
            FileInfo editorFileInfo = new FileInfo(EDITORS_FOLDER, EDITOR_TEMPLATE, "GameEventEditor", "UnityEditor");
            GenerateScript(editorFileInfo);
            
            AssetDatabase.Refresh();
        }
        
        // template paths
        private string BASE_TEMPLATE_PATH => Application.dataPath + "/SO Game Events/Editor Window/Templates";
        private readonly string EVENT_TEMPLATE = "/EventTemplate.txt";
        private readonly string LISTENER_TEMPLATE = "/ListenerTemplate.txt";
        private readonly string EDITOR_TEMPLATE = "/GameEventEditorTemplate.txt";
        
        // code generation paths
        private string CODE_GENERATION_FOLDER => Application.dataPath + "/CODE_GENERATION";
        private readonly string EVENTS_FOLDER = "/Game Events";
        private readonly string LISTENERS_FOLDER = "/Listeners";
        private readonly string EDITORS_FOLDER = "/Editor";

        private class FileInfo
        {
            public string scriptFolder;
            public string templateFolder;
            public string classSuffix;
            public string[] scriptNamespaces;

            public FileInfo(string scriptFolder, string templateFolder, string classSuffix, params string[] scriptNamespaces)
            {
                this.scriptFolder = scriptFolder;
                this.templateFolder = templateFolder;
                this.classSuffix = classSuffix;
                this.scriptNamespaces = scriptNamespaces;
            }
        }
        
        private void GenerateScript(FileInfo fileInfo)
        {
            string scriptPath = CODE_GENERATION_FOLDER + fileInfo.scriptFolder + $"/{className}{fileInfo.classSuffix}.cs";
            string templatePath = BASE_TEMPLATE_PATH + fileInfo.templateFolder;
            
            string templateText = File.ReadAllText(templatePath);
            string namespaceStr = GetNamespace(classNamespace, fileInfo.scriptNamespaces);
            string scriptContent = string.Format(templateText, namespaceStr, className);

            File.WriteAllText(scriptPath, scriptContent);
        }

        private string GetNamespace(string inputField, params string[] scriptNamespaces)
        {
            if (inputField == null)
            {
                return "";
            }

            if (scriptNamespaces.Contains(inputField))
            {
                return "";
            }
            
            return $"using {inputField};";
        }

        private void CreateFolders()
        {
            string eventsFolder = CODE_GENERATION_FOLDER + EVENTS_FOLDER;
            if (!Directory.Exists(eventsFolder))
            {
                Directory.CreateDirectory(eventsFolder);
            }
            
            string listenersFolder = CODE_GENERATION_FOLDER + LISTENERS_FOLDER;
            if (!Directory.Exists(listenersFolder))
            {
                Directory.CreateDirectory(listenersFolder);
            }
            
            string editorsFolder = CODE_GENERATION_FOLDER + EDITORS_FOLDER;
            if (!Directory.Exists(editorsFolder))
            {
                Directory.CreateDirectory(editorsFolder);
            }
        }
    }
}
#endif
