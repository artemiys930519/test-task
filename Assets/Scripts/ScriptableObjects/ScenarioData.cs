using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(ScenarioData), menuName = "Scenario Data", order = 51)]
    public class ScenarioData : ScriptableObject
    {
        public int MaxScore;
    }
}