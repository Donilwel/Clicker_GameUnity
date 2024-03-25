using System.Collections.Generic;

namespace Core
{
    public class ResourceBank
    {
        public ResourceBank(int humans = 0, int food = 0, int wood = 0, int stone = 0, int gold = 0)
        {
            _bank = new Dictionary<GameResource, ObservableInt>
      {
        {GameResource.Humans, new ObservableInt(humans)},
        {GameResource.Food, new ObservableInt(food)},
        {GameResource.Wood, new ObservableInt(wood)},
        {GameResource.Stone, new ObservableInt(stone)},
        {GameResource.Gold, new ObservableInt(gold)}
      };
        }

        private readonly Dictionary<GameResource, ObservableInt> _bank;

        public void ChangeResource(GameResource resource, int value)
          => _bank[resource].Value += value;

        public ObservableInt GetResource(GameResource resource)
          => _bank[resource];
    }
}