using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfRedactor.Class;

namespace WpfRedactor.MD
{
    public class MonD
    {
        private string connection = "mongodb://localhost:27017";
        private IMongoDatabase database;

        public MonD()
        {
            var client = new MongoClient(connection);
            database = client.GetDatabase("WpfRedactor");
        }

        public void AddUser(Unit user)
        {
            var collection = database.GetCollection<Unit>("WpfHeroes");
            collection.InsertOne(user);
        }

        public List<Unit> FindAll()
        {
            var collection = database.GetCollection<Unit>("WpfHeroes");
            var list = collection.Find(x => true).ToList();
            return list;
        }
        public void Find(string name)
        {
            var collection = database.GetCollection<Unit>("WpfHeroes");
            var one = collection.Find(x => x.name == name).FirstOrDefault();
            if(one != null)
            {
                MessageBox.Show($" Name - {one.name} {"\n"}Health - {one.health} {"\n"} Damage - {one.damage} {"\n"}  {"\n"} Armor - {one.armor} {"\n"} Mana - {one.mane}");
            }
            else
            {
                MessageBox.Show("Не найден");
            }
        }
        public void ReplaceByName(string name, Unit user1)
        {
            var collection = database.GetCollection<Unit>("WpfHeroes");
            collection.ReplaceOne(x => x.name == name, user1);
        }
    }

}
