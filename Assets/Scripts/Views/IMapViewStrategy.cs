using System.Collections.Generic;

namespace Views
{
    public interface IMapViewStrategy
    {
        void DrawMap(List<CellView> cellList);
    }
}
