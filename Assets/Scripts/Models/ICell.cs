using System;

namespace Models
{
    public interface ICell 
    {
        event Action<int> OnCellChanged;
    }
}
