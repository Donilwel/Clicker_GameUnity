namespace Core
{
    public class ObservableInt
    {
        private int v;
        public System.Action<int> OnValueChanged;

        public int Value
        {
            get
            {
                return v;
            }
            set
            {
                OnValueChanged?.Invoke(value);
                v = value;
            }
        }


        public ObservableInt(int val)
        {
            v = val;
        }
    }
}