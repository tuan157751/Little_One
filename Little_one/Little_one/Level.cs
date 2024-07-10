using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Little_one
{

    
public class Level 
    {
        Setting set = new Setting();
        Tiles tile;
        public Player player;
        public TileMap map{ get; set; }
        public List<Tiles> tiles { get; private set; } = new List<Tiles>();

        public List<Tiles> VisibleTiles { get; private set; } = new List<Tiles>();
        public Level() {  }
        public void create_map()
        {
            // Create an Dictionary to store Json File the their key (label)
            Dictionary<string, string> JsonFiles= new Dictionary<string, string>();
            JsonFiles.Add("Boundary", "C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\Little_one\\Data\\map\\FloorBlock.json");
            JsonFiles.Add("Grass", "C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\Little_one\\Data\\map\\Grass.json");
            JsonFiles.Add("Object", "C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\Little_one\\Data\\map\\Objects.json");


            foreach (KeyValuePair<string, string> ele1 in JsonFiles)
            {
                if (ele1.Key == "Boundary")
                {
                    map = LoadMap(ele1.Value);
                    for (int row = 0; row < map.data.GetLength(0); row++)
                    {

                        for (int col = 0; col < map.data.GetLength(1); col++)
                        {
                            //Console.Write(map.data[row, col] + " ");
                            int x = col * set.tile_size;
                            int y = row * set.tile_size;
                            if (map.data[row, col] == 395)
                            {
                                tile = new Tiles(x, y);
                                tiles.Add(tile);

                            }
                        }

                        //Console.WriteLine();
                    }
                }
            }
            
            //map = LoadMap("C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\Little_one\\Data\\tmx\\FloorBlock.json");

            
            
            //Console.Write(map.data.GetLength(0));
            /*for (int row = 0; row < set.WORLD_MAP.GetLength(0); row++)
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
                }*/
            //player= new Player();

        }
        public static TileMap LoadMap(string path)
        {
            string json = File.ReadAllText(path);
           // Console.WriteLine(json);
            return JsonConvert.DeserializeObject<TileMap>(json);
        }
    }
}
