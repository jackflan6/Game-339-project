using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SelectableEnemy))]
public class EnemyDropDown : Editor
{
    int _choiceIndex = 0;
    Lazy<Dictionary<string, int>> _choices = new Lazy<Dictionary<string, int>>(() => {
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Enemy)));
        Dictionary<string, int> ret = new Dictionary<string, int>();
        int i = 0;
        foreach (Type t in c)
        {
            ret.Add((int)t.GetField("enemyID").GetValue(null) + ": " + t.Name,
                (int)t.GetField("enemyID").GetValue(null));
            ++i;
        }
        ret.OrderBy(inp => inp.Value);
        return ret;
    }
    );


    public override void OnInspectorGUI()
    {
        string[] keys = _choices.Value.Keys.ToArray();
        Array.Sort(keys, _choices.Value.Values.ToArray());
        int i = 0;
        foreach (string choice in keys)
        {
            if (((SelectableEnemy)target).enemyID == _choices.Value[choice])
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, keys);
        var someClass = target as SelectableEnemy;
        int enemyID = _choices.Value[keys[_choiceIndex]];
        if (someClass.enemyID != enemyID)
        {
            someClass.enemyID = enemyID;
            EditorUtility.SetDirty(target);
        }


        //serializedObject.FindProperty("enemyID").intValue = enemyID;
        //serializedObject.ApplyModifiedProperties();
        DrawDefaultInspector();
    }
}
