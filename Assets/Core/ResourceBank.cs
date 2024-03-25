using System.Collections.Generic;

namespace Core
{
  public class ResourceBank
  {
        private readonly Dictionary<GameResource, ObservableInt> _gameBank;

        public ResourceBank(int humans = 0, int food = 0, int wood = 0, int stone = 0, int gold = 0)
    {
      _gameBank = new Dictionary<GameResource, ObservableInt>
      {
        {GameResource.Humans, new ObservableInt(humans)},
        {GameResource.Food, new ObservableInt(food)},
        {GameResource.Wood, new ObservableInt(wood)},
        {GameResource.Stone, new ObservableInt(stone)},
        {GameResource.Gold, new ObservableInt(gold)}
      };
    }     
    public void ChangeResource(GameResource r, int v)
      => _gameBank[r].Value += v;

    public ObservableInt GetResource(GameResource r)
      => _gameBank[r];
  }
}