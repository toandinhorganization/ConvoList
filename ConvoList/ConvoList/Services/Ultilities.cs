using System;
using Microsoft.Maui.Controls;

namespace ConvoList.Services
{
    public static class Ultilities
    {
        public static Rect GetElementBoundsWithPosition(VisualElement element)
        {
            if (element != null)
            {
                var bounds = element.Bounds;
                return bounds;
            }

            return Rect.Zero; 
        }
        public static bool IsPositionInBound(VisualElement element, Point position)
        {
            if (element != null)
            {
                var bounds = GetElementBoundsWithPosition(element);
                return bounds.Contains(position);
            }
            return false;
        }
    }
}
