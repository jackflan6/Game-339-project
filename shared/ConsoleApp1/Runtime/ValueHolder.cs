using System;
using System.Runtime.Serialization;

[Serializable]
public class ValueHolder<T>
{
    private T val;
    public event Action<T> ValueChanged;
    public ValueHolder(T i)
    {
        val = i;
    }
    public ValueHolder() {}
    public T Value {
        get { 
            return val;
        }
        set { 
        val = value;
        if (ValueChanged != null) ValueChanged.Invoke(val);
        } 
    }
    public static implicit operator ValueHolder<T>(T v) => new ValueHolder<T>(v);
    public static implicit operator T(ValueHolder<T> v) => v.val;
}
