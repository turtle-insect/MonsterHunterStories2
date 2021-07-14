using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterStories2
{
    class TransText
    {
        public static string[,] LanguageTexts = new string[,]
        {
            //Japanese,English,Korean
            {
                "File",
                "Open...",
                "Save",
                "Save As...",
                "Exit",
                "Basic",
                "Character",
                "Monster",
                "Weapon",
                "Item",
                "Money",
                "Name",
                "Body Type",
                "Face Shape",
                "Skin",
                "Hairstyle",
                "Eyes",
                "Mouth",
                "Makeup",
                "Voice",
                "male",
                "woman",
                "Do not set anything but the Lv and Name, except for the main character.",
                "Name",
                "Type",
                "Type Name",
                "Append/Search Item"
            },
            //Chinese
            {
                "文件",
                "打开...",
                "保存",
                "另存为",
                "关闭",
                "基础",
                "任务",
                "随从",
                "武器",
                "物品",
                "金币",
                "名字",
                "体型",
                "脸型",
                "皮肤",
                "发型",
                "眼睛",
                "嘴型",
                "装扮",
                "声音",
                "男性",
                "女性",
                "除了主角只能设置等级和名字。",
                "名字",
                "类型",
                "类型名称",
                "添加/搜索物品"
            },

        };
        public static Dictionary<string, int> Languages = new Dictionary<string, int>()     //key is language, value is LanguageTexts index
        {
            {"Japanese",0},
            {"English",0},
            {"Korean",0},
            {"简体中文",1}
        
        };
    }
}
