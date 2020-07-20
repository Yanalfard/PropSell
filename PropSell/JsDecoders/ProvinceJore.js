//---> int id
//---> string Name
function AddProvince(province)
{
    return Bjax('/api/ProvinceCore/AddProvince', province, 'LP');
}
function DeleteProvince(id)
{
    return Bjax('/api/ProvinceCore/DeleteProvince?id=', id, 'SP');
}
function UpdateProvince(province, logId)
{
    var provinceLogId = new Array();
    provinceLogId.push(province);
    provinceLogId.push(logId);
    return Bjax('/api/ProvinceCore/UpdateProvince', provinceLogId, 'LP');
}
function SelectAllProvinces()
{
    return Bjax('/api/ProvinceCore/SelectAllProvinces', '', 'G');
}
function SelectProvinceById(id)
{
    return Bjax('/api/ProvinceCore/SelectProvinceById?id=', id, 'SP');
}
function SelectProvinceByName(name)
{
    return Bjax('/api/ProvinceCore/SelectProvinceByName?name=', name, 'SP');
}
