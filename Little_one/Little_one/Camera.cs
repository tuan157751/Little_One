using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Little_one;

namespace Little_one
{
    public class Camera
    {
        public Size screenSize;
        public PointF cameraPosition;

        public Camera(Size screenSize)
        {
            this.screenSize = screenSize;
            this.cameraPosition = new PointF(0, 0);
        }

        public void Update(PointF playerPosition)
        {
            cameraPosition = new PointF ( playerPosition.X -screenSize.Width/2 ,   playerPosition.Y - screenSize.Height / 2);
            
        }

        public PointF ApplyTransform(PointF position)
        {
            float x = position.X - cameraPosition.X;
            float y = position.Y - cameraPosition.Y;
            return new PointF(x,y);
        }
    }
}
