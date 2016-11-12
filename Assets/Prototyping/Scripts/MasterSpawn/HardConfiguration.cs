
using System.Collections;

namespace AppConfiguration
{
    public class HardConfiguration
    {

        private static int _maxDifficulty = 10;
        private static float _spawnInterval = 2f;
		public static float MinY;
		public static float MaxY; 


        public static int MaxDifficulty
        {
            get { return _maxDifficulty; }
        }
        public static float SpawnInterval
        {
            get { return _spawnInterval; }
        }
       



    }


}
