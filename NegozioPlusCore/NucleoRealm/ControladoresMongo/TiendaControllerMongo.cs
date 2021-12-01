using MongoDB.Bson;
using NegozioPlusCore.NucleoRealm.ModelosBson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NegozioPlusCore.NucleoRealm.ControladoresMongo
{
    public class TiendaControllerMongo
    {
        Realms.Sync.MongoClient.Collection<TiendaMongo> ColeccionLocal;
        public TiendaControllerMongo()
        {
            Conectar();
            ColeccionLocal = Configuracion.Instanciar()._databaseMongo.GetCollection<TiendaMongo>("Tiendas");
        }

        public async Task<ObservableCollection<TiendaMongo>> ObtenerTodosAsync()
        {            
            TiendaMongo[] dat =await ColeccionLocal.FindAsync();
            ObservableCollection<TiendaMongo> datosLista = new ObservableCollection<TiendaMongo>(dat);            
            return datosLista;
        }
        public async Task AgregarAsync(TiendaMongo dato)
        {          
            try
            {
                await ColeccionLocal.InsertOneAsync(dato);
            }
            catch (Exception ex)
            {
                MessageBox.Show("errro:"+ex.Message);
                throw;
            }            
        }

        public async Task modificarAsync(TiendaMongo dato)
        {            
            try
            {                
                BsonDocument query = new BsonDocument { { "_id", dato._id } };
                //Builders<>
                BsonDocument update = new BsonDocument();                
                BsonElement a = new BsonElement("$set", new BsonDocument(new BsonElement("nombre", dato.nombre)));
                update.Add(a);               
                await ColeccionLocal.FindOneAndUpdateAsync(query, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("errro:" + ex.Message);
                throw;
            }
        }

        public void Conectar()
        {            
            Configuracion.Instanciar().ConectarMongoDB();
        }
    }
}
