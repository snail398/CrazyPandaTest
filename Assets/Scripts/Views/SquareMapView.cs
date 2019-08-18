using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class SquareMapView: IMapViewStrategy
    {
        public void DrawMap(List<CellView> cellList)
        {
            int i = 0;
            int j = 0;
            int rowcount = (int) Mathf.Sqrt(cellList.Count);
            int size = Screen.width / rowcount;
            Vector2 cellSize = new Vector2(size, size);
            foreach (var cellView in cellList)
            {
                cellView.RectTransform.sizeDelta = cellSize;
                Vector2 nextPos = new Vector2(-Screen.width / 2 + size * (0.5f + i), -Screen.height / 2 + 300 + size *(0.5f + j));
                cellView.RectTransform.localPosition = nextPos;
                i++;
                if (i % rowcount == 0)
                {
                    i = 0;
                    j++;
                }
            }
        }
    }
}
