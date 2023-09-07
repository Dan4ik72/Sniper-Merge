using System;

public interface IBuffable
{
    public Type BuffableType { get; }
    
    public void ApplyBuff(Buff buff);

    public void EndBuff(Buff buff);
}