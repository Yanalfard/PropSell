//---> int id
//---> string Name
//---> int ProvinceId
function AddCity(city)
{
    return Bjax('/api/CityCore/AddCity', city, 'LP');
}
function DeleteCity(id)
{
    return Bjax('/api/CityCore/DeleteCity?id=', id, 'SP');
}
function UpdateCity(city, logId)
{
    var cityLogId = new Array();
    cityLogId.push(city);
    cityLogId.push(logId);
    return Bjax('/api/CityCore/UpdateCity', cityLogId, 'LP');
}
function SelectAllCitys()
{
    return Bjax('/api/CityCore/SelectAllCitys', '', 'G');
}
function SelectCityById(id)
{
    return Bjax('/api/CityCore/SelectCityById?id=', id, 'SP');
}
function SelectCityByName(name)
{
    return Bjax('/api/CityCore/SelectCityByName?name=', name, 'SP');
}
function SelectCityByProvinceId(provinceId)
{
    return Bjax('/api/CityCore/SelectCityByProvinceId?provinceId=', provinceId, 'SP');
}
