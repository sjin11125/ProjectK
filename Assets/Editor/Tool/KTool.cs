using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class KTool : EditorWindow
{
    [MenuItem("Tools/Scene Setting")]
    // Start is called before the first frame update
    static void InitWindow()
    {
        KTool w = (KTool)EditorWindow.GetWindow(typeof(KTool));
        w.Show();
    }
    private void OnGUI()
    {

        GUILayout.Label("\n관련 씬", EditorStyles.boldLabel);
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("시작화면씬"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/Start.unity");
            }
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("로비씬"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/Lobby.unity");
            }
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("룸씬"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/Room.unity");
            }
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("게임씬"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");

            }
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("멀티게임씬"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/Multi.unity");
            }
        }
        //GUILayout.Space( 1f );
        //using (new EditorGUILayout.HorizontalScope())
        //{
        //    GUILayout.Space( 3f );
        //    if (GUILayout.Button( "�α���" ))
        //    {
        //        if (EditorSceneManager.GetActiveScene().isDirty)
        //        {
        //            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        //        }
        //        EditorSceneManager.OpenScene( "Assets/Scenes/LoginScene.unity" );
        //    }
        //}
        /*GUILayout.Space(1f);
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Space(3f);
            if (GUILayout.Button("��Ʋ��"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/BattleScene.unity");
            }
            GUILayout.Space(3f);
            if (GUILayout.Button("������"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/DungeonScene.unity");
            }
            GUILayout.Space(3f);
            if (GUILayout.Button("�����"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/DungeonSubScene/BankSubScene.unity");
            }
            GUILayout.Space(3f);
        }

        GUILayout.Space(1f);
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Space(3f);
            if (GUILayout.Button("ȥ�ɾ�"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/DungeonSubScene/SoulRuinSubScene.unity");
            }
            GUILayout.Space(3f);
            if (GUILayout.Button("��ų��"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/DungeonSubScene/SkillRuinSubScene.unity");
            }
            GUILayout.Space(3f);
            if (GUILayout.Button("���庸����"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/WorldBossScene.unity");
            }
            GUILayout.Space(3f);
        }

        GUILayout.Space(1f);
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Space(3f);
            if (GUILayout.Button("ĳ�û�����"))
            {
                if (EditorSceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                }
                EditorSceneManager.OpenScene("Assets/Scenes/TestScene.unity");
            }
        }

        GUILayout.Space(1f);
        */

    }

}
