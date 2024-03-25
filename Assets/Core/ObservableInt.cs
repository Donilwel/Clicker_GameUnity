namespace Core
{
    public class ObservableInt
    {
        private int _value;
        public System.Action<int> OnValueChanged;

        public int Value
        {
            get => _value;
            set
            {
                OnValueChanged?.Invoke(value);
                _value = value;
            }
        }


        public ObservableInt(int value)
        {
            _value = value;
        }
    }
}