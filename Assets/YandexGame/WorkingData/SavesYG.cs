
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        public int count;
        public int coin;
        public int level;
        public int playerCounter;
        public int firstTime;
        public int pourcentage;
        public int activSkin;
        public int skin0;
        public int skin1;
        public int skin2;
        public int skin3;
        public int skin4;
        public int skin5;
        public int skin6;
        public int skin7;
        public int skin8;
        public int menu;
        public int skin;
        public int main;
        public float checkpointPositionX;
        public float checkpointPositionY;
        public float checkpointPositionZ;
        public float checkpointRotationX;
        public float checkpointRotationY;
        public float checkpointRotationZ;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
