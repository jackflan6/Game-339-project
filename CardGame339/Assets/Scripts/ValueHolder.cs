using System;

public class ValueHolder<T>
{
    private T val;
    public event Action<T> ValueChanged;
    public T Value {
        get { 
            return val;
        }
        set { 
        val = value;
        if (ValueChanged != null) ValueChanged.Invoke(val);
        } 
    }

}
