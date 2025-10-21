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
    Lazy<string[]> _choices = new Lazy<string[]>(() => {
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Enemy)));
        string[] ret = new string[c.Count()];
        int i = 0;
        foreach (Type t in c)
        {
            ret[i] = ((int)t.GetField("enemyID").GetValue(null) + ": " + t.Name);
            ++i;
        }
        return ret;
    }
    );


    public override void OnInspectorGUI()
    {
        int i = 0;
        foreach (string choice in _choices.Value)
        {
            if (((SelectableEnemy)target).enemyID == (int)Char.GetNumericValue(choice[0]))
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.Value);
        var someClass = target as SelectableEnemy;
        int enemyID = (int)Char.GetNumericValue(_choices.Value[_choiceIndex][0]);
        someClass.enemyID = enemyID;
        //if (someClass.cardID != cardID)
        //{
        //    serializedObject.FindProperty("enemyID").intValue = cardID;
        //    serializedObject.ApplyModifiedProperties();
        //}
        // Draw the default inspector
        DrawDefaultInspector();
    }
}
