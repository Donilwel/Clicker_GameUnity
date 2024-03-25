using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private const int START_HUMANS_VALUE = 10;
        private const int START_FOOD_VALUE = 5;
        private const int START_WOOD_VALUE = 5;

        private ResourceBank _resourceBank;

        private void Awake()
          => _resourceBank = new ResourceBank(START_HUMANS_VALUE, START_FOOD_VALUE, START_WOOD_VALUE);

        public ResourceBank GetResourceBank()
          => _resourceBank;
    }
}