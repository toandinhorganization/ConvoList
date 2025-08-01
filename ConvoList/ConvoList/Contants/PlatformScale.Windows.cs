using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Contants
{
    public class PlatformScale
    {
        public static int NavbarWidthLarge { get; private set; } = 300;//Long width layout
        public static int NavbarWidthSmall { get; private set; } = 50;//Short width layout (close)

        public static bool IsLargeLayout
        {
            get
            {
                return DeviceDisplay.MainDisplayInfo.Width > 1200;
            }
        }
        
    }
}
