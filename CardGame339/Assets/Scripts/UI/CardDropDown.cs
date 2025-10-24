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
        int i = 0;
        foreach (string choice in _choices.Value.Keys)
        {
            if (((SelectableCard)target).cardID == _choices.Value[choice])
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.Value.Keys.ToArray());
        var someClass = target as SelectableCard;
        int cardID = _choices.Value[_choices.Value.Keys.ToArray()[_choiceIndex]];

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
