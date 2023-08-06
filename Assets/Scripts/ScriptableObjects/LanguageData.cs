using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(LanguageData), menuName = "Language Data", order = 51)]
    public class LanguageData : ScriptableObject
    {
        public string InteractedEnemyText = "Обижено уходит";
        public string FailResult = "К сожалению вы проиграли";
        public string CatchedResult = "Вы были обнаружены";
        public string SuccesResult = "Вы успешно справились с заданием";
    }
}