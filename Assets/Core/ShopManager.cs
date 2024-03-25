using UnityEngine;

namespace Core
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameManager _manager;
        [SerializeField] private ProductionBuilding[] _productionBuildings;
        private ResourceBank bankomat;

        private void Start()
        {
            bankomat = _manager.GetResourceBank();
        }

        public void BuyProductionLevel(SellPosition position)
        {
            if (bankomat.GetResource(position.Currency).Value >= position.Cost)
            {
                _productionBuildings[(int)position.TargetProduction].IncreaseProductionLevel();
                bankomat.ChangeResource(position.Currency, -position.Cost);
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }
    }
}