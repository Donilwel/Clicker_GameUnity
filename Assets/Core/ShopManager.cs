using UnityEngine;

namespace Core
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameManager _manager;
        [SerializeField] private ProductionBuilding[] _productionBuildings;
        private ResourceBank _bank;

        private void Start()
          => _bank = _manager.GetResourceBank();

        public void BuyProductionLevel(SellPosition position)
        {
            if (_bank.GetResource(position.Currency).Value >= position.Cost)
            {
                _productionBuildings[(int)position.TargetProduction].IncreaseProductionLevel();
                _bank.ChangeResource(position.Currency, -position.Cost);
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }
    }
}