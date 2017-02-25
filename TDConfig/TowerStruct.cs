
using System.Collections.Generic;

namespace TDConfig
{
    public struct TowerStruct
    {
        //public string towerType;
        public string name;
        public string description;
        public string element;
        public float damage;
        public float damage_radius;
        public float damage_freq;
        public float bulletSpeed;
        public string tile_type;
        public float cost;
        public string nextTowerType;

        public override string ToString()
        {
            string res = "<towerName:" + name + ">";
            res += "<towerDescription:" + description + ">";
            res += "<towerElement:" + element + ">";
            res += "<towerDamage:" + damage + ">";
            res += "<towerDamageRadius:" + damage_radius + ">";
            res += "<towerDamageFreq:" + damage_freq + ">";
            res += "<towerBulletSpeed:" + bulletSpeed + ">";
            res += "<towerTileType:" + tile_type + ">";
            res += "<towerCost:" + cost + ">";
            res += "<towerNextType:" + nextTowerType + ">";
            return res;
        }

        // Десериализация из строки
        public static TowerStruct Parse(string value)
        {
            // value = "<towerName:tower1><towerDescription:First Tower><towerElement:Fire><towerDamage:1><towerDamageRadius:3><towerDamageFreq:2><towerBulletSpeed:3><towerTileType:><towerCost:50><towerNextType:tower2>"
            TowerStruct ret = new TowerStruct();
            // Разбить строку на части по разделителям '<' и '>'
            List<string> values = UtilsParse.ParseType(value);
            // Цикл по элементам
            for (int i = 0; i < values.Count; i++)
            {
                // Разделить на код и значение
                string[] p = UtilsParse.Split(values[i], ':');
                // Проверка правильности сериализация (ошибка сериализации)
                if (p.Length != 2) throw new System.ArgumentException("Error in TowerStruct parameters ", "idx=" + i.ToString());

                // Перенос значений в поля структуры
                switch (p[0])
                {
                    case "towerName":
                        ret.name = p[1];
                        break;
                    case "towerDescription":
                        ret.description = p[1];
                        break;
                    case "towerElement":
                        ret.element = p[1];
                        break;
                    case "towerDamage":
                        ret.damage = float.Parse(p[1]);
                        break;
                    case "towerDamageRadius":
                        ret.damage_radius = float.Parse(p[1]);
                        break;
                    case "towerDamageFreq":
                        ret.damage_freq = float.Parse(p[1]);
                        break;
                    case "towerBulletSpeed":
                        ret.bulletSpeed = float.Parse(p[1]);
                        break;
                    case "towerTileType":
                        ret.tile_type = p[1];
                        break;
                    case "towerCost":
                        ret.cost = float.Parse(p[1]);
                        break;
                    case "towerNextType":
                        ret.nextTowerType = p[1];
                        break;
                }
            }
            return ret;
        }
    }
}
