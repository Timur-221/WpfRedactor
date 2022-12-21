using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WpfRedactor.Class
{
    [BsonKnownTypes(typeof(Warrior), typeof(Wizard), typeof(Rouge))]
    public class Unit
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        public string name { get; set; }

        public int health { get; set; }
        public int damage { get; set; }
        public int armor { get; set; }
        public int mane { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelegence { get; set; }

        public Unit(string name, int health, int damage, int armor, int mane, int strength, int dexterity, int constitution, int intelegence)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.armor = armor;
            this.mane = mane;
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelegence = intelegence;
        }

        public Unit(string name, int health, int damage, int armor, int mane, int strength)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.armor = armor;
            this.mane = mane;
            this.strength = strength;
        }
    }
}
