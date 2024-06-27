namespace Brts.Audible;

public interface IAudible<T>
{
    void OnChange(Action<T> handler);
    T Value { set; get; }
}

public class Audible<T> : IAudible<T>
{
    public Audible(T value)
    {
        _value = value;
    }

    private Action<T>? _handler;
    public void OnChange(Action<T> handler)
    {
        _handler = handler;
    }

    private T _value;
    public T Value
    {
        set
        {
            _value = value;
            if(_handler is not null) 
            {
                _handler(_value);
            }
        }

        get => _value;
    }
}
