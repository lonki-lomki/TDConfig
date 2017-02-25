
using System.Collections.Generic;

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
            // value = "<mobName:m1><mobSpeed:1,6><mobHP:1><mobDamage:1><mobExp:1>"
            MobStruct ret = new MobStruct();
            // Разбить строку на части по разделителям '<' и '>'
            List<string> values = UtilsParse.ParseType(value);
            // Цикл по элементам
            for (int i = 0; i < values.Count; i++)
            {
                // Разделить на код и значение
                string[] p = UtilsParse.Split(values[i], ':');
                // Проверка правильности сериализация (ошибка сериализации)
                if (p.Length != 2) throw new System.ArgumentException("Error in MobStruct parameters ", "idx=" + i.ToString());

                // Перенос значений в поля структуры
                switch (p[0])
                {
                    case "mobName":
                        ret.name = p[1];
                        break;
                    case "mobSpeed":
                        ret.speed = float.Parse(p[1]);
                        break;
                    case "mobHP":
                        ret.hp = float.Parse(p[1]);
                        break;
                    case "mobDamage":
                        ret.damage = float.Parse(p[1]);
                        break;
                    case "mobExp":
                        ret.exp = float.Parse(p[1]);
                        break;
                }
            }
            return ret;
        }
    }
}
