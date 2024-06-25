using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Little_one
{

    
public class Level 
    {
        Setting set = new Setting();
        Tiles tile;
        public List<Tiles> tiles { get; private set; } = new List<Tiles>();
        public void create_map()
        {
            for (int row = 0; row < set.WORLD_MAP.GetLength(0); row++)
                for (int col = 0; col < set.WORLD_MAP.GetLength(1); col++)
                {
                    int x = col * set.tile_size;
                    int y = row * set.tile_size;
                    if (set.WORLD_MAP[row,col] == 'x')
                    {
                        tile = new Tiles(x, y);
                        tiles.Add(tile);
                        //Console.WriteLine("found");
                    }
                }
        }
        public void update_map()
        {
           
        }
    }
}
