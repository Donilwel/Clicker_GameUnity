using UnityEngine;

namespace Core
{
  public class ShopManager : MonoBehaviour
  {
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ProductionBuilding[] _productionBuildings;
    private ResourceBank _resourceBank;

        private void Start()
        {
            _resourceBank = _gameManager.GetResourceBank();
        }
    
    public void BuyProductionLevel(SellPosition position)
    {
      if (_resourceBank.GetResource(position.Currency).Value >= position.Cost)
      {
        _productionBuildings[(int)position.TargetProduction].IncreaseProductionLevel();
        _resourceBank.ChangeResource(position.Currency, -position.Cost);
      }
      else
      {
        Debug.Log("Not enough money!");
      }
    }
  }
}