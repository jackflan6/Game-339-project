using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SelectableCard))]
public class CardDropDown : Editor
{
    int _choiceIndex = 0;
    Lazy<Dictionary<string,int>> _choices = new Lazy<Dictionary<string, int>>(() => {
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Card)));
        Dictionary<string,int> ret = new Dictionary<string,int>();
        int i = 0;
        foreach (Type t in c)
        {
            ret.Add((int)t.GetField("cardID").GetValue(null) + ": " + t.Name, 
                (int)t.GetField("cardID").GetValue(null));
            ++i;
        }

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
            if (((SelectableCard)target).cardID == _choices.Value[choice])
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex,keys);
        var someClass = target as SelectableCard;
        int cardID = _choices.Value[keys[_choiceIndex]];

        if (someClass.cardID != cardID)
        {
            someClass.cardID = cardID;
            EditorUtility.SetDirty(target);
        }
        //if (someClass.cardID != cardID)
        //{
        //serializedObject.FindProperty("cardID").intValue = cardID;
        //serializedObject.ApplyModifiedProperties();
        //}
        // Draw the default inspector
        DrawDefaultInspector();
    }
}
