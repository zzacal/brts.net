namespace Brts.Audible;

public interface IAudibleAsync<T>
{
    void OnChange(Func<T, Task> handler);
    Task Set(T value);

    T Get();
}

public class AudibleAsync<T> : IAudibleAsync<T>
{
    public AudibleAsync(T value)
    {
        _value = value;
    }

    private T _value;

    public async Task Set(T value)
    {
        _value = value;

        if(_handler is not null)
        {
            await _handler(_value);
        }
    }

    public T Get() => _value;
    private Func<T, Task>? _handler;
    public void OnChange(Func<T, Task> handler)
    {
        _handler = handler;
    }
}

