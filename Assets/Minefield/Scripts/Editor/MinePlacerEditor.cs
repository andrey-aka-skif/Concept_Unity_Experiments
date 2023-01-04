using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Minefield
{
    public class MinePlacerEditor : EditorWindow
    {
        private Transform _clonedObject;
        private Transform _root;
        private Vector2Int _array = Vector2Int.one;
        private float _shift = 1.0f;

        private List<string> _errors = new List<string>();

        [MenuItem("Window/Mine Placer Editor")]
        public static void ShowWindow()
        {
            MinePlacerEditor window = (MinePlacerEditor)GetWindow(typeof(MinePlacerEditor));
            window.Show();
        }

        void OnGUI()
        {
            // размещаемый объект
            GUILayout.Label("Источник", EditorStyles.boldLabel);
            _clonedObject = (Transform)EditorGUILayout.ObjectField(_clonedObject, typeof(Transform), true);

            // корень
            GUILayout.Label("Разместить относительно родителя", EditorStyles.boldLabel);
            _root = (Transform)EditorGUILayout.ObjectField(_root, typeof(Transform), true);

            // настройки массива
            GUILayout.Label("Настройки массива", EditorStyles.boldLabel);
            _array = EditorGUILayout.Vector2IntField("Размер массива", _array);
            _shift = EditorGUILayout.FloatField("Интервал", _shift);

            // получение ошибок
            _errors = CheckErrors();

            if (_errors.Any())
            {
                EditorGUILayout.HelpBox(_errors.FirstOrDefault(), MessageType.Warning);
            }

            EditorGUI.BeginDisabledGroup(_errors.Any());
            {
                if (GUILayout.Button("Расположить", GUILayout.ExpandWidth(true), GUILayout.Height(50)))
                {
                    Placer.Place(_clonedObject, _root, _array, _shift);
                }
            }
            EditorGUI.EndDisabledGroup();
        }

        private List<string> CheckErrors()
        {
            var errors = new List<string>();

            if (_clonedObject == null)
                errors.Add("Не выбран объект для размещения");

            if (_root == null)
                errors.Add("Не выбран родитель для размещения");

            if (_root == _clonedObject)
                errors.Add($"Попытка разместить объект {_clonedObject.transform.name} относительно самого себя");

            return errors;
        }
    }
}
