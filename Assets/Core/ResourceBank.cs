using System.Collections.Generic;

namespace Core
{
    public class ResourceBank
    {
        public ResourceBank(int humans, int food, int wood, int stone, int gold)
        {
            bankomat = new Dictionary<GameResource, ObservableInt>
      {
        {GameResource.Humans, new ObservableInt(humans)},
        {GameResource.Food, new ObservableInt(food)},
        {GameResource.Wood, new ObservableInt(wood)},
        {GameResource.Stone, new ObservableInt(stone)},
        {GameResource.Gold, new ObservableInt(gold)}
      };
        }

        private readonly Dictionary<GameResource, ObservableInt> bankomat;

        public void ChangeResource(GameResource r, int v)
        {
            bankomat[r].Value += v;
        }

        public ObservableInt GetResource(GameResource r)
        {
            return bankomat[r];
        }
    }
}