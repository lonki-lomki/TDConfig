
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

            return ret;
        }
    }
}
