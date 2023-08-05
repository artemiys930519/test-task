using Core.UI.Panels;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = "Level Data", order = 51)]
    public class LevelData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject EnemyPrefab;
        public MainPanel UIPrefab;
    }
}