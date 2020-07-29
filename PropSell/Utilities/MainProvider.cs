using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using PropSell.Models.Regular;

namespace PropSell.Utilities
{
    public class MainProvider
    {
        private static readonly string ConnectionString = Config.ConnectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _commandText = "";

        public MainProvider()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void _disconnect()
        {
            _command.Dispose();
            _connection.Close();
        }

        public enum Tables
        {
            TblFriends,
            TblImage,
            TblClick,
            TblPropertyImageRel,
            TblConstructor,
            TblDealer,
            TblClient,
            TblPropertyClientRel,
            TblProvince,
            TblCity,
            TblProperty
        }

        public enum PropertyImageRel
        {
            PropertyId,
            ImageId
        }

        public enum PropertyClientRel
        {
            PropertyId,
            UserId,
        }

        public object Add<T>(T table)
        {
            //try
            //{
            object tableObj = table;
            SqlCommand command;
            if (table.GetType() == typeof(TblFriends))
            {
                TblFriends friends = (TblFriends)tableObj;

                _commandText = $"insert into TblFriends (MeId , FriendId , Status) values (N'{friends.MeId}' , N'{friends.FriendId}' , N'{friends.Status}')";
                command = new SqlCommand($"select TOP (1) * from TblFriends where MeId = N'{friends.MeId}' ORDER BY id DESC", _connection);
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0);
            }
            else if (table.GetType() == typeof(TblImage))
            {
                TblImage image = (TblImage)tableObj;
                _commandText = $"insert into TblImage (Name) values (N'{image.Name}' )";
                command = new SqlCommand($"select TOP (1) * from TblImage where Name = N'{image.Name}' ORDER BY id DESC", _connection);
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new TblImage(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
            }
            else if (table.GetType() == typeof(TblClick))
            {
                TblClick click = (TblClick)tableObj;

                _commandText = $"insert into TblClick (Date , PropertyId) values (N'{click.Date}' , N'{click.PropertyId}' )";
                command = new SqlCommand($"select TOP (1) * from TblClick where Date = N'{click.Date}' ORDER BY id DESC", _connection);
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new TblClick(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Date"].ToString(), reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0);
            }
            else if (table.GetType() == typeof(TblPropertyImageRel))
            {
                TblPropertyImageRel propertyImageRel = (TblPropertyImageRel)tableObj;

                _commandText = $"insert into TblPropertyImageRel (PropertyId , ImageId) values (N'{propertyImageRel.PropertyId}' , N'{propertyImageRel.ImageId}' )";
                command = new SqlCommand($"select TOP (1) * from TblPropertyImageRel where PropertyId = N'{propertyImageRel.PropertyId}' ORDER BY id DESC", _connection);
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new TblPropertyImageRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["ImageId"].ToString() != "" ? Convert.ToInt32(reader["ImageId"]) : 0);
            }
            else if (table.GetType() == typeof(TblConstructor))
            {
                TblConstructor constructor = (TblConstructor)tableObj;
                if (!MethodRepo.ExistInDb("TblConstructor", "TellNo", constructor.TellNo))
                {
                    _commandText = $"insert into TblConstructor (TellNo , Identification , Address) values (N'{constructor.TellNo}' , N'{constructor.Identification}' , N'{constructor.Address}' )";
                    command = new SqlCommand($"select TOP (1) * from TblConstructor where TellNo = N'{constructor.TellNo}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblConstructor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString());
                }
                else return new TblConstructor(-1);
            }

            else if (table.GetType() == typeof(TblDealer))
            {
                TblDealer dealer = (TblDealer)tableObj;
                if (!MethodRepo.ExistInDb("TblDealer", "Name", dealer.Name))
                {
                    _commandText = $"insert into TblDealer (TellNo , Identification , Address , Name) values (N'{dealer.TellNo}' , N'{dealer.Identification}' , N'{dealer.Address}' , N'{dealer.Name}' )";
                    command = new SqlCommand($"select TOP (1) * from TblDealer where Name = N'{dealer.Name}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString());
                }
                else return new TblDealer(-1);
            }

            else if (table.GetType() == typeof(TblClient))
            {
                TblClient client = (TblClient)tableObj;
                if (!MethodRepo.ExistInDb("TblClient", "TellNo", client.TellNo))
                {
                    _commandText = $"insert into TblClient (TellNo , Identification) values (N'{client.TellNo}' , N'{client.Identification}' )";
                    command = new SqlCommand($"select TOP (1) * from TblClient where TellNo = N'{client.TellNo}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblClient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString());
                }
                else return new TblClient(-1);
            }

            else if (table.GetType() == typeof(TblPropertyClientRel))
            {
                TblPropertyClientRel propertyClientRel = (TblPropertyClientRel)tableObj;

                _commandText = $"insert into TblPropertyClientRel (PropertyId , UserId , Status , PostDate) values (N'{propertyClientRel.PropertyId}' , N'{propertyClientRel.UserId}' , N'{propertyClientRel.Status}' , N'{propertyClientRel.PostDate}')";
                command = new SqlCommand($"select TOP (1) * from TblPropertyClientRel where PropertyId = N'{propertyClientRel.PropertyId}' ORDER BY id DESC", _connection);
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new TblPropertyClientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0, reader["PostDate"].ToString());
            }
            else if (table.GetType() == typeof(TblProvince))
            {
                TblProvince province = (TblProvince)tableObj;
                if (!MethodRepo.ExistInDb("TblProvince", "Name", province.Name))
                {
                    _commandText = $"insert into TblProvince (Name) values (N'{province.Name}' )";
                    command = new SqlCommand($"select TOP (1) * from TblProvince where Name = N'{province.Name}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblProvince(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                }
                else return new TblProvince(-1);
            }

            else if (table.GetType() == typeof(TblCity))
            {
                TblCity city = (TblCity)tableObj;
                if (!MethodRepo.ExistInDb("TblCity", "Name", city.Name))
                {
                    _commandText = $"insert into TblCity (Name , ProvinceId) values (N'{city.Name}' , N'{city.ProvinceId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblCity where Name = N'{city.Name}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblCity(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["ProvinceId"].ToString() != "" ? Convert.ToInt32(reader["ProvinceId"]) : 0);
                }
                else return new TblCity(-1);
            }

            else if (table.GetType() == typeof(TblProperty))
            {
                TblProperty property = (TblProperty)tableObj;
                if (!MethodRepo.ExistInDb("TblProperty", "Title", property.Title))
                {
                    _commandText = $"insert into TblProperty (Title , Description , Valid , ShowToFriends , UserId , CityId , Neighborhood , Price , IsOnFirstPage) values (N'{property.Title}' , N'{property.Description}' , N'{property.Valid}' , N'{property.ShowToFriends}' , N'{property.UserId}' , N'{property.CityId}' , N'{property.Neighborhood}' , N'{property.Price}' , N'{property.IsOnFirstPage}')";
                    command = new SqlCommand($"select TOP (1) * from TblProperty where Title = N'{property.Title}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0, reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false);
                }
                else return new TblProperty(-1);
            }

            _command = new SqlCommand(_commandText, _connection);
            _command.ExecuteNonQuery();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //finally
            //{
            //    _disconnect();
            //}
        }

        public bool Update<T>(T table, int logId)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblFriends))
                {
                    TblFriends friends = (TblFriends)tableObj;
                    _commandText = $"update TblFriends set MeId = N'{friends.MeId}' , FriendId = N'{friends.FriendId}' , Status = N'{friends.Status}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblImage))
                {
                    TblImage image = (TblImage)tableObj;
                    _commandText = $"update TblImage set Name = N'{image.Name}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblClick))
                {
                    TblClick click = (TblClick)tableObj;
                    _commandText = $"update TblClick set Date = N'{click.Date}' , PropertyId = N'{click.PropertyId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPropertyImageRel))
                {
                    TblPropertyImageRel propertyImageRel = (TblPropertyImageRel)tableObj;
                    _commandText = $"update TblPropertyImageRel set PropertyId = N'{propertyImageRel.PropertyId}' , ImageId = N'{propertyImageRel.ImageId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblConstructor))
                {
                    TblConstructor constructor = (TblConstructor)tableObj;
                    _commandText = $"update TblConstructor set TellNo = N'{constructor.TellNo}' , Identification = N'{constructor.Identification}' , Address = N'{constructor.Address}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblDealer))
                {
                    TblDealer dealer = (TblDealer)tableObj;
                    _commandText = $"update TblDealer set TellNo = N'{dealer.TellNo}' , Identification = N'{dealer.Identification}' , Address = N'{dealer.Address}' , Name = N'{dealer.Name}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblClient))
                {
                    TblClient client = (TblClient)tableObj;
                    _commandText = $"update TblClient set TellNo = N'{client.TellNo}' , Identification = N'{client.Identification}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPropertyClientRel))
                {
                    TblPropertyClientRel propertyClientRel = (TblPropertyClientRel)tableObj;
                    _commandText = $"update TblPropertyClientRel set PropertyId = N'{propertyClientRel.PropertyId}' , UserId = N'{propertyClientRel.UserId}' , Status = N'{propertyClientRel.Status}' , PostDate = N'{propertyClientRel.PostDate}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblProvince))
                {
                    TblProvince province = (TblProvince)tableObj;
                    _commandText = $"update TblProvince set Name = N'{province.Name}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblCity))
                {
                    TblCity city = (TblCity)tableObj;
                    _commandText = $"update TblCity set Name = N'{city.Name}' , ProvinceId = N'{city.ProvinceId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblProperty))
                {
                    TblProperty property = (TblProperty)tableObj;
                    _commandText = $"update TblProperty set Title = N'{property.Title}' , Description = N'{property.Description}' , Valid = N'{property.Valid}' , ShowToFriends = N'{property.ShowToFriends}' , UserId = N'{property.UserId}' , CityId = N'{property.CityId}' , Neighborhood = N'{property.Neighborhood}' , Price = N'{property.Price}' , IsOnFirstPage = N'{property.IsOnFirstPage}' where id = N'{logId}'";
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Delete(Tables tableType, int id)
        {
            try
            {
                _commandText = $"delete from {tableType.ToString()} where id = N'{id}'";
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public IEnumerable SelectAll(Tables tableType)
        {
            try
            {
                _commandText = $"select * from {tableType.ToString()}";
                _command = new SqlCommand(_commandText, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                switch (tableType)
                {
                    case Tables.TblFriends:
                        List<TblFriends> friendses = new List<TblFriends>();
                        while (reader.Read())
                            friendses.Add(new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0));
                        return friendses;
                    case Tables.TblImage:
                        List<TblImage> images = new List<TblImage>();
                        while (reader.Read())
                            images.Add(new TblImage(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString()));
                        return images;
                    case Tables.TblClick:
                        List<TblClick> clicks = new List<TblClick>();
                        while (reader.Read())
                            clicks.Add(new TblClick(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Date"].ToString(), reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0));
                        return clicks;
                    case Tables.TblPropertyImageRel:
                        List<TblPropertyImageRel> propertyImageRels = new List<TblPropertyImageRel>();
                        while (reader.Read())
                            propertyImageRels.Add(new TblPropertyImageRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["ImageId"].ToString() != "" ? Convert.ToInt32(reader["ImageId"]) : 0));
                        return propertyImageRels;
                    case Tables.TblConstructor:
                        List<TblConstructor> constructors = new List<TblConstructor>();
                        while (reader.Read())
                            constructors.Add(new TblConstructor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString()));
                        return constructors;
                    case Tables.TblDealer:
                        List<TblDealer> dealers = new List<TblDealer>();
                        while (reader.Read())
                            dealers.Add(new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString()));
                        return dealers;
                    case Tables.TblClient:
                        List<TblClient> clients = new List<TblClient>();
                        while (reader.Read())
                            clients.Add(new TblClient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString()));
                        return clients;
                    case Tables.TblPropertyClientRel:
                        List<TblPropertyClientRel> propertyClientRels = new List<TblPropertyClientRel>();
                        while (reader.Read())
                            propertyClientRels.Add(new TblPropertyClientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0, reader["PostDate"].ToString()));

                        return propertyClientRels;
                    case Tables.TblProvince:
                        List<TblProvince> provinces = new List<TblProvince>();
                        while (reader.Read())
                            provinces.Add(new TblProvince(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString()));
                        return provinces;
                    case Tables.TblCity:
                        List<TblCity> cities = new List<TblCity>();
                        while (reader.Read())
                            cities.Add(new TblCity(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["ProvinceId"].ToString() != "" ? Convert.ToInt32(reader["ProvinceId"]) : 0));
                        return cities;
                    case Tables.TblProperty:
                        List<TblProperty> properties = new List<TblProperty>();
                        while (reader.Read())
                            properties.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                        return properties;
                    default:
                        return new List<bool>();
                }
            }
            catch
            {
                return new List<bool>();
            }
            finally
            {
                _disconnect();
            }
        }

        public object SelectById(Tables table, int id)
        {
            try
            {
                _command = new SqlCommand($"select * from {table.ToString()} where id = N'{id}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                if (table == Tables.TblFriends)
                    return new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0);
                else if (table == Tables.TblImage)
                    return new TblImage(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                else if (table == Tables.TblClick)
                    return new TblClick(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Date"].ToString(), reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0);
                else if (table == Tables.TblPropertyImageRel)
                    return new TblPropertyImageRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["ImageId"].ToString() != "" ? Convert.ToInt32(reader["ImageId"]) : 0);
                else if (table == Tables.TblConstructor)
                    return new TblConstructor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString());
                else if (table == Tables.TblDealer)
                    return new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString());
                else if (table == Tables.TblClient)
                    return new TblClient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString());
                else if (table == Tables.TblPropertyClientRel)
                    return new TblPropertyClientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0, reader["PostDate"].ToString());
                else if (table == Tables.TblProvince)
                    return new TblProvince(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                else if (table == Tables.TblCity)
                    return new TblCity(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["ProvinceId"].ToString() != "" ? Convert.ToInt32(reader["ProvinceId"]) : 0);
                else if (table == Tables.TblProperty)
                    return new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false);
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _disconnect();
            }
        }

        #region TblFriends

        public List<TblFriends> SelectFriendsByMeId(int meId)
        {
            try
            {
                List<TblFriends> ret = new List<TblFriends>();
                _command = new SqlCommand($"select* from TblFriends where MeId = N'{meId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblFriends>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblFriends> SelectFriendsByFriendId(int friendId)
        {
            try
            {
                List<TblFriends> ret = new List<TblFriends>();
                _command = new SqlCommand($"select* from TblFriends where FriendId = N'{friendId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblFriends>();
            }
            finally
            {
                _disconnect();
            }
        }        public List<TblFriends> SelectFriendsByFriendIdAndMeId(int friendId, int meId)
        {
            try
            {
                List<TblFriends> ret = new List<TblFriends>();
                _command = new SqlCommand($"select* from TblFriends where FriendId = N'{friendId}' and MeId = N'{meId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblFriends(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["MeId"].ToString() != "" ? Convert.ToInt32(reader["MeId"]) : 0, reader["FriendId"].ToString() != "" ? Convert.ToInt32(reader["FriendId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblFriends>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblImage

        public TblImage SelectImageByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblImage where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblImage(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
            }
            catch
            {
                return new TblImage(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblClick

        public List<TblClick> SelectClickByPropertyId(int propertyId)
        {
            try
            {
                List<TblClick> ret = new List<TblClick>();
                _command = new SqlCommand($"select* from TblClick where PropertyId = N'{propertyId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblClick(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Date"].ToString(), reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblClick>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPropertyImageRel

        public List<TblPropertyImageRel> SelectPropertyImageRel(int entry, PropertyImageRel entryType)
        {
            try
            {
                List<TblPropertyImageRel> ret = new List<TblPropertyImageRel>();
                if (entryType == PropertyImageRel.PropertyId)
                    _command = new SqlCommand($"select* from TblPropertyImageRel where PropertyId = N'{entry}'", _connection);
                else if (entryType == PropertyImageRel.ImageId)
                    _command = new SqlCommand($"select* from TblPropertyImageRel where ImageId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPropertyImageRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["ImageId"].ToString() != "" ? Convert.ToInt32(reader["ImageId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblPropertyImageRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblConstructor

        public TblConstructor SelectConstructorByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblConstructor where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblConstructor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString());
            }
            catch
            {
                return new TblConstructor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblConstructor> SelectConstructorByIdentification(int identification)
        {
            try
            {
                List<TblConstructor> ret = new List<TblConstructor>();
                _command = new SqlCommand($"select* from TblConstructor where Identification = N'{identification}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblConstructor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblConstructor>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblDealer

        public TblDealer SelectDealerByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDealer where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString());
            }
            catch
            {
                return new TblDealer(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblDealer> SelectDealerByIdentification(int identification)
        {
            try
            {
                List<TblDealer> ret = new List<TblDealer>();
                _command = new SqlCommand($"select* from TblDealer where Identification = N'{identification}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblDealer>();
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDealer SelectDealerByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDealer where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblDealer(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString(), reader["Address"].ToString(), reader["Name"].ToString());
            }
            catch
            {
                return new TblDealer(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblClient

        public TblClient SelectClientByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblClient where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblClient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString());
            }
            catch
            {
                return new TblClient(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblClient> SelectClientByIdentification(int identification)
        {
            try
            {
                List<TblClient> ret = new List<TblClient>();
                _command = new SqlCommand($"select* from TblClient where Identification = N'{identification}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblClient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["TellNo"].ToString(), reader["Identification"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblClient>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPropertyClientRel

        public List<TblPropertyClientRel> SelectPropertyClientRel(int entry, PropertyClientRel entryType)
        {
            try
            {
                List<TblPropertyClientRel> ret = new List<TblPropertyClientRel>();
                if (entryType == PropertyClientRel.PropertyId)
                    _command = new SqlCommand($"select* from TblPropertyClientRel where PropertyId = N'{entry}'", _connection);
                else if (entryType == PropertyClientRel.UserId)
                    _command = new SqlCommand($"select* from TblPropertyClientRel where UserId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPropertyClientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PropertyId"].ToString() != "" ? Convert.ToInt32(reader["PropertyId"]) : 0, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["Status"].ToString() != "" ? Convert.ToInt32(reader["Status"]) : 0, reader["PostDate"].ToString()));
                return ret;
            }
            catch
            {
                return new List<TblPropertyClientRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblProvince

        public TblProvince SelectProvinceByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblProvince where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblProvince(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
            }
            catch
            {
                return new TblProvince(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblCity

        public TblCity SelectCityByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblCity where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblCity(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["ProvinceId"].ToString() != "" ? Convert.ToInt32(reader["ProvinceId"]) : 0);
            }
            catch
            {
                return new TblCity(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblCity> SelectCityByProvinceId(int provinceId)
        {
            try
            {
                List<TblCity> ret = new List<TblCity>();
                _command = new SqlCommand($"select* from TblCity where ProvinceId = N'{provinceId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblCity(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["ProvinceId"].ToString() != "" ? Convert.ToInt32(reader["ProvinceId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblCity>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblProperty

        public List<TblProperty> SelectPropertyByTitle(string title)
        {
            try
            {
                List<TblProperty> res = new List<TblProperty>();
                _command = new SqlCommand($"select* from TblProperty where Title like N'%{title}%'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                res.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return res;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblProperty> SelectPropertyByValid(bool valid)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"select* from TblProperty where Valid = N'id'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblProperty> SelectPropertyByShowToFriends(bool showToFriends)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"select* from TblProperty where ShowToFriends = N'{showToFriends}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }        public List<TblProperty> SelectPropertyByIsOnFirstPage(bool isOnFirstPage)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"select top (10) * from TblProperty where ShowToFriends = N'{isOnFirstPage}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblProperty> SelectPropertyByUserId(int userId)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"select* from TblProperty where UserId = N'{userId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblProperty> SelectPropertyByCityId(int cityId)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"select* from TblProperty where CityId = N'{cityId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblProperty> SelectLatestProperties(int count)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"SELECT TOP({count}) * FROM dbo.TblProperty ORDER BY id DESC", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }

        public List<TblProperty> SelectPropertiesByPriceBetween(long min, long max)
        {
            try
            {
                List<TblProperty> ret = new List<TblProperty>();
                _command = new SqlCommand($"SELECT * FROM dbo.TblProperty WHERE Price >= N'{min}' AND Price <= N'{max}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblProperty(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Title"].ToString(), reader["Description"].ToString(), reader["Valid"].ToString() != "" ? Convert.ToBoolean(reader["Valid"]) : false, reader["ShowToFriends"].ToString() != "" ? Convert.ToBoolean(reader["ShowToFriends"]) : false, reader["UserId"].ToString() != "" ? Convert.ToInt32(reader["UserId"]) : 0, reader["CityId"].ToString() != "" ? Convert.ToInt32(reader["CityId"]) : 0, reader["Neighborhood"].ToString(), reader["Price"].ToString() != "" ? Convert.ToInt32(reader["Price"]) : 0,reader["IsOnFirstPage"].ToString() != "" ? Convert.ToBoolean(reader["IsOnFirstPage"]) : false));
                return ret;
            }
            catch
            {
                return new List<TblProperty>();
            }
            finally
            {
                _disconnect();
            }
        }
        #endregion

    }
}
