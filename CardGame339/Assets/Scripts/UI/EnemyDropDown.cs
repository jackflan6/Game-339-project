using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
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

        return ret;
    }
    );


    public override void OnInspectorGUI()
    {
        int i = 0;
        foreach (string choice in _choices.Value.Keys)
        {
            if (((SelectableEnemy)target).enemyID == _choices.Value[choice])
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.Value.Keys.ToArray());
        var someClass = target as SelectableEnemy;
        int enemyID = _choices.Value[_choices.Value.Keys.ToArray()[_choiceIndex]];
        someClass.enemyID = enemyID;
        DrawDefaultInspector();
    }
}
