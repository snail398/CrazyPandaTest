using System;

namespace Models
{
    public interface IPlayer
    {
        event Action OnNotEnoughShovel;
        event Action<int> OnSuccesfullDig;
    }
}
