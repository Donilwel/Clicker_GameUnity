using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {

        private ResourceBank _resourceBank;

        private void Awake()
          => _resourceBank = new ResourceBank(10, 5, 5, 0, 0);

        public ResourceBank GetResourceBank()
          => _resourceBank;
    }
}