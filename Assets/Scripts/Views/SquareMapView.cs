using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class SquareMapView : MonoBehaviour, IMapViewStrategy
    {
        public void DrawMap(List<CellView> cellList)
        {
            int i = 0;
            int j = 0;
            foreach (var cellView in cellList)
            {
                Vector2 nextPos = new Vector2(-250 + i * 250, -250 + j * 250);
                cellView.RectTransform.localPosition = nextPos;
                i++;
                if (i % 3 == 0)
                {
                    i = 0;
                    j++;
                }
            }
        }
    }
}
