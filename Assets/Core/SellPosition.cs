using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "SellPosition")]
  public class SellPosition : ScriptableObject
  {
    [SerializeField] public GameResource _gameResource;
    [SerializeField] private int _costs;
    [Space(15)] [SerializeField] private GameResource _target;

    public GameResource TargetProduction => _target;
    public GameResource Currency => _gameResource;
    public int Cost => _costs;
  }
}