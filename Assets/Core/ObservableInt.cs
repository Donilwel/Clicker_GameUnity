namespace Core
{
  public class ObservableInt
  {
    private int _v;
    public System.Action<int> OnValue;

    public int Value
    {
      get
      {
       return _v;
      }
      set
      {
        OnValue?.Invoke(value);
        _v = value;
      }
    }

    public ObservableInt(int v)
    {
      _v = v;
    }
  }
}