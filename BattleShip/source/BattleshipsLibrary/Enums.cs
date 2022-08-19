using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsLibrary
{
    public class Enums
    {
        
        public static string GetDescription(Enum enumName)
        {
            Type enumNameType = enumName.GetType();
            MemberInfo[] memberInfo = enumNameType.GetMember(enumName.ToString());
            if ((memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs.Count() > 0))
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return enumName.ToString();
        }
    }

    
    public enum ShipType
    {
        [Description("Nimic selectat!")]
        None = 0,

        [Description("Distrugător")]
        Destroyer = 1,

        [Description("Submarin")]
        Submarine = 2,

        [Description("Crucişător")]
        Cruiser = 3,

        [Description("Vas de război")]
        Battleship = 4,

        [Description("Portavion")]
        Carrier = 5,

        [Description("Atacator")]
        Attacker = 6,

        [Description("Titanic")]
        Titanic = 7
    }

    
    public enum TileType
    {
        Water,
        ShipCenterHorizontal,
        ShipCenterVertical,
        ShipEndLeft,
        ShipEndRight,
        ShipEndUp,
        ShipEndDown,
        ShipSolo
    }

    
    public enum PlacementType
    {
        Solo,
        Horizontal,
        Vertical,
        Invalid,
        Occupied
    }

    
    public enum UpdateType
    {
        PlayerGrid,
        EnemyGrid
    }

    
    public enum ResponseType
    {
        Accepted,
        Rejected
    }
}
