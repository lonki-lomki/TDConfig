
namespace TDConfig
{
    public struct MobStruct
    {
        public string name;
        public float speed;
        public float hp;
        public float damage;
        public float exp;
        //public string tile_type;

        // Сериализация в строку
        public override string ToString()
        {
            string res = "<mobName:" + name + ">";
            res += "<mobSpeed:" + speed + ">";
            res += "<mobHP:" + hp + ">";
            res += "<mobDamage:" + damage + ">";
            res += "<mobExp:" + exp + ">";
            return res;
        }

        // Десериализация из строки
        public static MobStruct Parse(string value)
        {
            MobStruct ret = new MobStruct();


            return ret;
        }
    }
}
