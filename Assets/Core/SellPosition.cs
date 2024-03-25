using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SellPosition")]
    public class SellPosition : ScriptableObject
    {
        [SerializeField] public GameResource _currencyType;
        [SerializeField] private int _cost;
        [Space(15)] [SerializeField] private GameResource _targetProduction;

        public GameResource TargetProduction => _targetProduction;
        public GameResource Currency => _currencyType;
        public int Cost => _cost;
    }
}